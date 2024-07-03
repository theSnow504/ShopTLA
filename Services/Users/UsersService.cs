using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ShopTLA.Models.Domain;
using ShopTLA.Models.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
        public string Login(UsersDTO users)
        {
            var data = _context.UserAccounts.FirstOrDefault(x => x.UserName == users.UserName && x.PassWord==users.PassWord);
            if (data != null)
            {
                //var tokenHandler = new JwtSecurityTokenHandler();
                //var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
                //var tokenDescriptor = new SecurityTokenDescriptor
                //{
                //    Subject = new ClaimsIdentity(new[] { new Claim("id", "1") }),
                //    Expires = DateTime.UtcNow.AddDays(7),
                //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                //};
                //var token = tokenHandler.CreateToken(tokenDescriptor);
                //return tokenHandler.WriteToken(token);
                var text = "thành công";
                return (text);
            }

            return null;
        }
    }
}
