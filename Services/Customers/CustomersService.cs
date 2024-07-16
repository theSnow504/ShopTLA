using Microsoft.EntityFrameworkCore;
using ShopTLA.Models.Domain;
using ShopTLA.Models.DTO;
using SmartBot.Common.Helpers;

namespace ShopTLA.Services.Customers
{
    public class CustomersService : ICustomersService
    {

        private readonly IConfiguration _configuration;
        private readonly ShopTlaContext _context;
        public CustomersService(ShopTlaContext dbcontext, IConfiguration configuration)
        {
            _context = dbcontext;
            _configuration=configuration;
        }
        public async Task<bool> AddCustomer(Customer customer)
        {
            if (customer != null)
            {
                await _context.Customers.AddAsync(customer);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<List<Customer>> GetAllCustomer(string token)
        {
            var id = int.Parse(Token.Authentication(token));
            var getuser = await _context.UserAccounts.FirstOrDefaultAsync(x => x.Id==id);
            if (getuser.TypeUser == 0)
            {
                var data = await _context.Customers.ToListAsync();
                return data;
            }
            return null;
        }

        public async Task<Customer> UpdateCustomer(string token, CustomerDTO customerDTO)
        {
            var id = int.Parse(Token.Authentication(token));
            var getuser = await _context.UserAccounts.FirstOrDefaultAsync(x => x.Id==id);
            var getcustomer = await _context.Customers.FirstOrDefaultAsync(x => x.CusId==getuser.Id);
            if (getcustomer!=null)
            {
                getcustomer.CusName=customerDTO.CusNameDTO;
                getcustomer.CusAddress=customerDTO.CusAddressDTO;
                getcustomer.CusPhone=customerDTO.CusPhoneDTO;
                getcustomer.CusDateOfBirth=customerDTO.CusDateOfBirthDTO;
                getcustomer.CusEmail=customerDTO.CusEmailDTO;
                getcustomer.CusLastUpdate=DateTime.UtcNow;
            }
            _context.Customers.Update(getcustomer);
            _context.SaveChanges();
            return getcustomer;
        }
    }
}
