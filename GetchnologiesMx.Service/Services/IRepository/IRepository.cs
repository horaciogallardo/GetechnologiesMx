using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetechnologiesMx.Service.Models;

namespace GetechnologiesMx.Service.Services.IRepository
{
    public interface IRepository<T> where T : class
    {
        public Task<ActionResult<IEnumerable<T>>> Get();
        public Task<ActionResult<T>> Create(T entity);
        public Task<IActionResult> Update(int id, T entity);
        public Task<IActionResult> Delete(int id);
    }
}
