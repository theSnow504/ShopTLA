using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopTLA.Models.Domain;
using ShopTLA.Models.DTO;
using ShopTLA.Services.Customers;
using ShopTLA.Services.Users;

namespace ShopTLA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ShopTlaContext _context;
        private readonly ICustomersService _customersService;
        public CustomerController(ShopTlaContext dbcontext, ICustomersService customersService)
        {
            _context = dbcontext;
            _customersService = customersService;
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
            var id = await _context.UserAccounts.FirstOrDefaultAsync(x => x.UserName == user);
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
            var data = await _customersService.AddCustomer(cus);
            if (data==false)
            {
                return ValidationProblem();
            }
            HttpContext.Session.Remove("UserRegister");
            return Ok(data);
        }

        [Route("GetAllCustomer")]
        [HttpGet]
        public async Task<IActionResult> GetAllCustomer(string token)
        {
            if (token == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid register request");
            }

            var data = await _customersService.GetAllCustomer(token);
            if (data==null)
            {
                return ValidationProblem();
            }

            return Ok(data);
        }

        [Route("UpdateCustomer")]
        [HttpPost]
        public async Task<IActionResult> UpdateCustomer(string token, CustomerDTO customerDTO)
        {
            if (token == null || customerDTO==null || !ModelState.IsValid)
            {
                return BadRequest("Invalid register request");
            }

            var data = await _customersService.UpdateCustomer(token,customerDTO);
            if (data==null)
            {
                return ValidationProblem();
            }

            return Ok(customerDTO);
        }
    }
}
