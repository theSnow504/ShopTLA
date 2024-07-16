using ShopTLA.Models.Domain;
using ShopTLA.Models.DTO;

namespace ShopTLA.Services.Products
{
    public interface IProductsService
    {
        public Task<Product?> AddProduct(ProductsDTO product);
        public Task<ProductDetail?> AddProductDetail(ProductDetailsDTO detailsDTO);
        public Task<Product?> GetProduct(int IdProd);
        //public Task<Product> UpdateProduct(Product product);
    }
}
