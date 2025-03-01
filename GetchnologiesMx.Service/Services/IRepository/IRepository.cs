using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetechnologiesMx.Service.Models;
using GetechnologiesMx.Service.Dtos;

namespace GetechnologiesMx.Service.Services.IRepository
{
    public interface IRepository<T> where T : class
    {
        public Task<ActionResult<IEnumerable<T>>> findPersonaByIdentificacion();
        public Task<ActionResult<IEnumerable<T>>> findPersonas();
        public Task<IActionResult> DeletePersonaByIdentificacion(int id);
        public Task<ActionResult<T>> StorePersona(T entity);

        public Task<ICollection<T>> findFacturasByPersona(string persona);
        public Task<ActionResult<T>> StoreFactura(T entity);
        public Task<IActionResult> DeleteVenta(int id); 
        public Task<IActionResult> UpdateVenta(int id, T entity);

        public Task<ActionResult<IEnumerable<T>>> Get();
        public Task<ActionResult<T>> Create(T entity);
        public Task<IActionResult> Update(int id, T entity);
        public Task<IActionResult> Delete(int id);
    }
}
