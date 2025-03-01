using GetechnologiesMx.API.Configurations;
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
    public class DirectorioRestServiceFacturaController : ControllerBase
    {
        private readonly IUnitOfwork _unitOfWork;
        IRepository<Factura> facturaRepository;

        public DirectorioRestServiceFacturaController(IUnitOfwork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            //facturaRepository = new FacturaRepository(_unitOfWork, "GetechnologiesMx");
            facturaRepository = new FacturaRepository(_unitOfWork);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Factura>>> GetFactura()
        {
            var facturas = await facturaRepository.Get();
            return facturas;
        }

        //[HttpPost]
        [HttpPost("CreateFactura")]
        public async Task<ActionResult<Factura>> CreateFactura(Factura factura)
        {
            var facturas = await facturaRepository.Create(factura);
            return facturas;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFactura(int id)
        {
            var facturas = await facturaRepository.Delete(id);
            return facturas;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFactura(int id, Factura factura)
        {
            var facturas = await facturaRepository.Update(id, factura);
            return facturas;
        }
    }
}