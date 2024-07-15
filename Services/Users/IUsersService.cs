using Microsoft.AspNetCore.Mvc;
using ShopTLA.Models.Domain;
using ShopTLA.Models.DTO;

namespace ShopTLA.Services.Users
{
    public interface IUsersService
    {
        public Task<string> Login(UsersDTO user);
        public Task<string> Register(RegisterDTO register);
        public bool Logout();
        public Task<bool> ChangePass(ChangePassDTO changePass);
        public Task<bool> AddCustomer(Customer customer);
        public Task<bool> AddEmployee(Employee employee);
    }
}
