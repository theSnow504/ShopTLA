using Microsoft.AspNetCore.Mvc;
using ShopTLA.Models.DTO;

namespace ShopTLA.Services.Users
{
    public interface IUsersService
    {
        public string Login(UsersDTO users);
    }
}
