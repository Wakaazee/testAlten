namespace TestAlten.WebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TestAlten.Domain;
    using TestAlten.Services.Interfaces;

    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService service, ILogger<ProductsController> logger)
        {
            _logger = logger;
            _productService = service;
        }

        private readonly ILogger<ProductsController> _logger;


        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productService.GetAllProducts();
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPost]
        public ActionResult<IEnumerable<Product>> CreateProduct([FromBody] Product product)
        {
            var productList = _productService.CreateProduct(product);
            return Ok(productList);
        }

        [HttpPatch("{id}")]
        public ActionResult<IEnumerable<Product>> UpdateProduct(int id, [FromBody] Product product)
        {
            var updatedProductlist = _productService.UpdateProduct(id, product);
            if (updatedProductlist == null)
            {
                return NotFound();
            }
            return Ok(updatedProductlist);
        }

        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<Product>> DeleteProduct(int id)
        {
            var productList = _productService.DeleteProduct(id);
            if(productList == null)
            {
                return NotFound();
            }
            return Ok(productList);
        }

        [HttpDelete]
        public IEnumerable<Product> DeleteProduct([FromBody] List<Product> products)
        {
            return _productService.DeleteProducts(products);
        }
    }
}
