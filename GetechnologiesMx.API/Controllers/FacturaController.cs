using GetechnologiesMx.API.Configurations;
using GetechnologiesMx.Service.Models;
using GetechnologiesMx.Service.Services.IRepository;
using GetechnologiesMx.Service.Services.IUnitOfworks;
using GetechnologiesMx.Service.Services.Repository;
using GetechnologiesMx.Service.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GetechnologiesMx.API.Controllers
{
    [ApiController]
    [ApiExceptionHandler]
    [Route("api/[controller]")]
    public class FacturaController : ControllerBase
    {
        private readonly IUnitOfwork _unitOfWork;
        IRepository<Factura> facturaRepository;

        public (IUnitOfwork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            facturaRepository = new FacturaRepository(_unitOfWork, "crud3");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Factura>>> GetFactura()
        {
            var products = await productRepository.Get();
            return products;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            var products = await productRepository.Create(product);
            return products;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var products = await productRepository.Delete(id);
            return products;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            var products = await productRepository.Update(id, product);
            return products;
        }
    }
}