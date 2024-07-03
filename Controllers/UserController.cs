using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ShopTLA.Models.Domain;
using ShopTLA.Models.DTO;
using ShopTLA.Services.Users;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShopTLA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ShopTlaContext _context;
        private readonly IUsersService _usersService;
        public UserController(ShopTlaContext dbcontext, IUsersService usersService) 
        {
            _context = dbcontext;
            _usersService = usersService;
        }
        //[HttpGet]
        //public ActionResult UserLogin()
        //{
            
        //}
        [HttpPost]
        public IActionResult UserLogin(UsersDTO users)
        {
            if (users == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid login request");
            }
            
            var token = _usersService.Login(users);
            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
