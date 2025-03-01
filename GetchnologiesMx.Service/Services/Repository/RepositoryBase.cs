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
using System.Linq.Expressions;
using GetechnologiesMx.Service.Dtos;


namespace GetechnologiesMx.Service.Services.Repository
{
    public abstract class RepositoryBase<T> : ControllerBase, IRepository<T> where T : class
    {
        //protected readonly DbContext _context;
        protected readonly ApiDbContext _apiDbContext;
        protected DbSet<T> dbSet;
        protected DbSet<T> dbSetContext;

        private readonly IUnitOfwork _unitOfWork;

        public RepositoryBase(IUnitOfwork unitOfwork,ApiDbContext _apiDbContext)
        {
            _unitOfWork = unitOfwork;
            dbSet = _unitOfWork.Context.Set<T>();
            dbSetContext = _apiDbContext.Set<T>();
        }

        //public RepositoryBase(IUnitOfwork unitOfwork, string procedureName) : this(unitOfwork)
        //{
        //}                               
        
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

        /// <summary>
        /// Personas
        /// </summary>
        /// <returns></returns>
        //Get Request
        public async Task<ActionResult<IEnumerable<T>>> findPersonaByIdentificacion()
        {
            var data = await dbSet.ToListAsync();
            return Ok(data);
        }

        //Get Request
        public async Task<ActionResult<IEnumerable<T>>> findPersonas()
        {
            var data = await dbSet.ToListAsync();
            return Ok(data);
        }

            ////Create Request
            //public async Task<ActionResult<T>> StorePersona(T entity)
            //{
            //    dbSet.Add(entity);
            //    await _unitOfWork.SaveChangesAsync();
            //    return entity;
            //}

        //Delete Request
        public async Task<IActionResult> DeletePersonaByIdentificacion(int id)
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
        ///


        /// <summary>
        ///  ventas
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        //Get Request
        //public async Task<ActionResult<IEnumerable<T>>> findFacturasByPersona(string persona)
        //{
        //    //var data = await dbSet.ToListAsync(persona);
        //    //var data = _apiDbContext.Persona.Where(p => p.Nombre == persona);
            
        //    //var data = _apiDbContext.Persona.GroupBy(p => p.Nombre == persona);
        //    //var dta = await _unitOfWork.GetType
        //    var data = dbSet.ToList(persona);
            
        //    return Ok(data);
        //}

        //public async Task<ICollection<T>> findFacturasByPersona(string persona)
        //{
        //    var data= await  _apiDbContext.Set<VentasDtos>().Where(persona).ToListAsync();
        //    return Ok(data);
        //}

        //public async Task<string> findFacturasByPersona(string persona)
        //{
        //    var data = dbSet.ToListAsync(_apiDbContext.Persona.Where(p => p.Nombre == persona));
        //    return Ok(data);
        //}

        public async Task<IList<Persona>> findFacturasByPersona(string persona)
        {
            //return data = await _apiDbContext.Persona.GroupBy(p => p.Nombre == persona).ToListAsync();
            var data = await dbSetContext
            return data;


        }

        //Create Request
        public async Task<ActionResult<T>> StoreFactura(T entity)
        {
            dbSet.Add(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        //Create Request
        public async Task<ActionResult<T>> StorePersona(T entity)
        {
            dbSet.Add(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        //Delete Request
        public async Task<IActionResult> DeleteVenta(int id)
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

        //Update Request
        public async Task<IActionResult> UpdateVenta(int id, T entity)
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

        ///  ventas


    }
}