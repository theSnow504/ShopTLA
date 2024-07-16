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
        public async Task<Product?> AddProduct(ProductsDTO product)
        {
            if (product != null)
            {
                var data = new Product()
                {
                    CatId=product.CatIdDTO,
                    NatId=product.NatIdDTO,
                    ProName=product.ProNameDTO,
                    ProDescription = product.ProDescriptionDTO,
                    ProLastUpdate = DateTime.UtcNow,
                };
                await _context.Products.AddAsync(data);
                await _context.SaveChangesAsync();
                return data;
            }
            return null;
        }

        public async Task<ProductDetail?> AddProductDetail(ProductDetailsDTO detailsDTO)
        {
            if (detailsDTO != null)
            {
                var data = new ProductDetail()
                {
                    ProId=detailsDTO.ProIdDTO,
                    PrdInventory=detailsDTO.PrdInventoryDTO,
                    PrdSize=detailsDTO.PrdSizeDTO,
                    PrdColor=detailsDTO.PrdColorDTO,
                    PrdPrice=detailsDTO.PrdPriceDTO,
                    PrdLastUpdate=DateTime.UtcNow,
                };
                await _context.ProductDetails.AddAsync(data);
                await _context.SaveChangesAsync();
                return data;
            }
            return null;
        }

        public async Task<Product?> GetProduct(int IdProd)
        {
            var data=await _context.Products.Include(x=>x.ProductDetails).FirstOrDefaultAsync(x=>x.ProId == IdProd);
            return data;
        }
    }
}
