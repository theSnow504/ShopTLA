using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ShopTLA.Models.Domain;
using ShopTLA.Models.DTO;
using SmartBot.Common.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;
using Microsoft.Win32;

namespace ShopTLA.Services.Users
{
    public class UsersService : IUsersService
    {
        private readonly IConfiguration _configuration;
        private readonly ShopTlaContext _context;
        public UsersService(ShopTlaContext dbcontext, IConfiguration configuration)
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

        public async Task<bool> AddEmployee(Employee employee)
        {
            if (employee != null)
            {
                await _context.Employees.AddAsync(employee);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> ChangePass(ChangePassDTO changePass)
        {
            if(changePass.PassWord!=changePass.ConfirmPassWord) return false;
            var idUser = int.Parse(Token.Authentication(changePass.Token));
            var data = _context.UserAccounts.FirstOrDefault(x => x.Id==idUser);
            if (data == null)
            {
                return false;
            }
            else
            {
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(changePass.PassWord);
                data.PassWord = hashedPassword;
                _context.UserAccounts.Update(data);
                await _context.SaveChangesAsync();
                return true;
            }    
        }

        public async Task<string> Login(UsersDTO user)
        {
            var data = _context.UserAccounts.FirstOrDefault(x => x.UserName == user.UserName);
            if (data == null)
            {
                return null;
            }
            bool isValidPassword = BCrypt.Net.BCrypt.Verify(user.PassWord, data.PassWord);
            if (!isValidPassword)
            {
                return null;
            }
            string token = Token.GenerateSecurityToken(data.Id, "7");
            return token;
        }

        public bool Logout()
        {
            
            throw new NotImplementedException();
        }

        public async Task<string> Register(RegisterDTO register)
        {
            if (register.PassWord!=register.ConfirmPassWord)
            {
                return null;
            }
            var checkExit = await _context.UserAccounts.FirstOrDefaultAsync(x => x.UserName == register.UserName);
            UserAccount newUser=new UserAccount();
            if (checkExit==null)
            {
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(register.PassWord);
                newUser = new UserAccount
                {
                    UserName = register.UserName,
                    //PassWord = register.PassWord, 
                    PassWord = hashedPassword,
                    TypeUser = 1,
                    Status =true,
                    LastUpdate = DateTime.UtcNow
                };
                await _context.UserAccounts.AddAsync(newUser);
                await _context.SaveChangesAsync();
                
                return newUser.UserName;
            }
            return null;
        }
    }
}
