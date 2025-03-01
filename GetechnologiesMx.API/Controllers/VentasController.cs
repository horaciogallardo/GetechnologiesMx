using GetechnologiesMx.API.Configurations;
using GetechnologiesMx.Service.Dtos;
using GetechnologiesMx.Service.Models;
using GetechnologiesMx.Service.Services.IRepository;
using GetechnologiesMx.Service.Services.IUnitOfworks;
using GetechnologiesMx.Service.Services.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GetechnologiesMx.API.Controllers
{
    [ApiController]
    [ApiExceptionHandler]
    [Route("api/[controller]")]
    public class VentasController : ControllerBase
    {
        private readonly IUnitOfwork _unitOfWork;
        IRepository<VentasDtos> ventasRepository;

        public VentasController(IUnitOfwork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            //ventasRepository = new VentasRepository(_unitOfWork, "GetechnologiesMx");
            ventasRepository = new VentasRepository(_unitOfWork);
        }

        //[HttpGet]
        [HttpGet("findFacturasByPersona/{persona}")]
        public async Task<ICollection<VentasDtos>> findFacturasByPersona(string persona)
        {
            var ventas = await ventasRepository.findFacturasByPersona(persona);
            return ventas;
        }

        //[HttpPost]
        [HttpPost("StorePersona")]
        public async Task<ActionResult<VentasDtos>> StoreFactura(VentasDtos venta)
        {
            var ventas = await ventasRepository.StorePersona(venta);
            return ventas;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenta(int id)
        {
            var ventas = await ventasRepository.Delete(id);
            return ventas;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVenta(int id, VentasDtos venta)
        {
            var ventas = await ventasRepository.Update(id, venta);
            return ventas;
        }
    }
}