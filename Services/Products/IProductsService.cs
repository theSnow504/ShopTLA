using ShopTLA.Models.Domain;
using ShopTLA.Models.DTO;

namespace ShopTLA.Services.Products
{
    public interface IProductsService
    {
        public Task<Product> AddProduct(ProductsDTO product);
        //public Task<Product> UpdateProduct(Product product);
    }
}
