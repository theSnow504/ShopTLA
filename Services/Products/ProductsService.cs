using Microsoft.EntityFrameworkCore;
using ShopTLA.Models.Domain;
using ShopTLA.Models.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ShopTLA.Services.Products
{
    public class ProductsService : IProductsService
    {
        private readonly IConfiguration _configuration;
        private readonly ShopTlaContext _context;
        public ProductsService(ShopTlaContext dbcontext, IConfiguration configuration)
        {
            _context = dbcontext;
            _configuration=configuration;
        }
        public async Task<Product> AddProduct(ProductsDTO product)
        {
            if (product != null)
            {
                var data = new Product()
                {
                    CatId=product.CatIdDTO,
                    NatId=product.NatIdDTO,
                    ProName=product.ProNameDTO,
                    ProPrice = product.ProPriceDTO,
                    ProDescription = product.ProDescriptionDTO,
                    ProLastUpdate = product.ProLastUpdateDTO
                };
                await _context.Products.AddAsync(data);
                await _context.SaveChangesAsync();
                return data;
            }
            return null;

        }
    }
}
