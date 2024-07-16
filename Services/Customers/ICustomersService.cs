using ShopTLA.Models.Domain;
using ShopTLA.Models.DTO;

namespace ShopTLA.Services.Customers
{
    public interface ICustomersService
    {
        public Task<bool> AddCustomer(Customer customer);
        public Task<List<Customer>> GetAllCustomer(string token);
        public Task<Customer> UpdateCustomer(string token, CustomerDTO customerDTO);
    }
}
