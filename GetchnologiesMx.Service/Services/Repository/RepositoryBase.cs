using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GetechnologiesMx.Service.DataContext;
using GetechnologiesMx.Service.Models;
using GetechnologiesMx.Service.Services.IUnitOfworks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GetechnologiesMx.Service.Services.IRepository;


namespace GetechnologiesMx.Service.Services.Repository
{
    public abstract class RepositoryBase<T> : ControllerBase, IRepository<T> where T : class
    {
        protected readonly DbContext _context;
        protected DbSet<T> dbSet;
        private readonly IUnitOfwork _unitOfWork;

        public RepositoryBase(IUnitOfwork unitOfwork)
        {
            _unitOfWork = unitOfwork;
            dbSet = _unitOfWork.Context.Set<T>();
        }

        public RepositoryBase(IUnitOfwork unitOfwork, string procedureName) : this(unitOfwork)
        {
        }

        //Get Request
        public async Task<ActionResult<IEnumerable<T>>> Get()
        {
            var data = await dbSet.ToListAsync();
            return Ok(data);
        }

        //Create Request
        public async Task<ActionResult<T>> Create(T entity)
        {
            dbSet.Add(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        //Update Request
        public async Task<IActionResult> Update(int id, T entity)
        {
            //if (id !=  entity.Id)
            if (id != 0)
            {
                return BadRequest();
            }

            var existingOrder = await dbSet.FindAsync(id);
            if (existingOrder == null)
            {
                return NotFound();
            }

            _unitOfWork.Context.Entry(existingOrder).CurrentValues.SetValues(entity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        //Delete Request
        public async Task<IActionResult> Delete(int id)
        {
            var data = await dbSet.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            dbSet.Remove(data);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }
    }
}