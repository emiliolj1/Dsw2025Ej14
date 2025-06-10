using Microsoft.AspNetCore.Mvc;
using Dsw2025Ej14.Api.Data;
using Dsw2025Ej14.Api.Domain;

namespace Dsw2025Ej14.Api.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IPersistencia _persistencia;

        public ProductsController(IPersistencia persistencia)
        {
            _persistencia = persistencia;
        }
        [HttpGet]
        public IActionResult GetProuducts()
        {
            var products = _persistencia.GetProducts();
            if (products?.Any() == false) return NoContent();
            return Ok(products);
        }
        [HttpGet("{sku}")]

        public IActionResult GetBySku(string sku)
        {
            var product = _persistencia.GetBySku(sku);

            if (product == null)
                return NotFound();

            return Ok(product);
        }
    }
}
