using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopTLA.Models.Domain;
using ShopTLA.Models.DTO;
using ShopTLA.Services.Products;
using ShopTLA.Services.Users;

namespace ShopTLA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ShopTlaContext _context;
        private readonly IProductsService _productsService;
        public ProductController(ShopTlaContext dbcontext, IProductsService productsService)
        {
            _context = dbcontext;
            _productsService = productsService;
        }
        [Route("AddProduct")]
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductsDTO products)
        {
            if (products == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid register request");
            }
            var data = await _productsService.AddProduct(products);
            if (data!=null)
            {
                return ValidationProblem();
            }
            return Ok(data);
        }
    }
}
