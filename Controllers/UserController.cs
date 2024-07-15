using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ShopTLA.Models.Domain;
using ShopTLA.Models.DTO;
using ShopTLA.Services.Users;
using System;
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

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> UserLogin(UsersDTO users)
        {
            if (users == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid login request");
            }

            var token = await _usersService.Login(users);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }


        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> UserRegister(RegisterDTO users)
        {
            if (users == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid register request");
            }
            
            var data =await _usersService.Register(users);
            if (data==null)
            {
                return ValidationProblem();
            }
            HttpContext.Session.SetString("UserRegister", data);
            return Ok(data);
        }

        [Route("AddCustomer")]
        [HttpPost]
        public async Task<IActionResult> AddCustomer(CustomerDTO customer)
        {
            if (customer == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid register request");
            }
            var user = HttpContext.Session.GetString("UserRegister");
            var id= await _context.UserAccounts.FirstOrDefaultAsync(x=>x.UserName == user);
            if (id==null)
            {
                return ValidationProblem();
            }    
            var cus = new Customer()
            {
                CusId=id.Id,
                CusName=customer.CusNameDTO,
                CusDateOfBirth=customer.CusDateOfBirthDTO,
                CusAddress=customer.CusAddressDTO,
                CusPhone=customer.CusPhoneDTO,
                CusEmail=customer.CusEmailDTO,
                CusLastUpdate=customer.CusLastUpdateDTO,
            };
            var data = await _usersService.AddCustomer(cus);
            if (data==false)
            {
                return ValidationProblem();
            }
            HttpContext.Session.Remove("UserRegister");
            return Ok(data);
        }

        [Route("AddEmployee")]
        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeDTO employee)
        {
            if (employee == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid register request");
            }
            var user = HttpContext.Session.GetString("UserRegister");
            var id = await _context.UserAccounts.FirstOrDefaultAsync(x => x.UserName == user);
            if (id==null)
            {
                return ValidationProblem();
            }
            var cus = new Employee()
            {
                EmpId=id.Id,
                EmpName=employee.EmpNameDTO,
                EmpDateOfBirth=employee.EmpDateOfBirthDTO,
                EmpAddress=employee.EmpAddressDTO,
                EmpPhone=employee.EmpPhoneDTO,
                EmpEmail=employee.EmpEmailDTO,
                EmpSalary=employee.EmpSalaryDTO,
                EmpLastUpdate=employee.EmpLastUpdateDTO,
            };
            var data = await _usersService.AddEmployee(cus);
            if (data==false)
            {
                return ValidationProblem();
            }
            HttpContext.Session.Remove("UserRegister");
            return Ok(data);
        }

        [Route("ChangePass")]
        [HttpPost]
        public async Task<IActionResult> UserChangePass(ChangePassDTO users)
        {
            if (users == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid register request");
            }

            var data = await _usersService.ChangePass(users);
            if (data==false)
            {
                return ValidationProblem();
            }

            return Ok(data);
        }
    }
}
