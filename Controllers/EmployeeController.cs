using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopTLA.Models.Domain;
using ShopTLA.Models.DTO;
using ShopTLA.Services.Customers;
using ShopTLA.Services.Employees;

namespace ShopTLA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ShopTlaContext _context;
        private readonly IEmployeesService _employeesService;
        public EmployeeController(ShopTlaContext dbcontext, IEmployeesService employeesService)
        {
            _context = dbcontext;
            _employeesService = employeesService;
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
            var data = await _employeesService.AddEmployee(cus);
            if (data==false)
            {
                return ValidationProblem();
            }
            HttpContext.Session.Remove("UserRegister");
            return Ok(data);
        }
        [Route("GetAllEmployee")]
        [HttpGet]
        public async Task<IActionResult> GetAllEmployee(string token)
        {
            if (token == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid register request");
            }

            var data = await _employeesService.GetAllEmployee(token);
            if (data==null)
            {
                return ValidationProblem();
            }

            return Ok(data);
        }
    }
}
