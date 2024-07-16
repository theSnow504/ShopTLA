using Microsoft.EntityFrameworkCore;
using ShopTLA.Models.Domain;
using SmartBot.Common.Helpers;

namespace ShopTLA.Services.Employees
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IConfiguration _configuration;
        private readonly ShopTlaContext _context;
        public EmployeesService(ShopTlaContext dbcontext, IConfiguration configuration)
        {
            _context = dbcontext;
            _configuration=configuration;
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
        public async Task<List<Employee>> GetAllEmployee(string token)
        {
            var id = int.Parse(Token.Authentication(token));
            var getuser = await _context.UserAccounts.FirstOrDefaultAsync(x => x.Id==id);
            if (getuser.TypeUser == 0)
            {
                var data = await _context.Employees.ToListAsync();
                return data;
            }
            return null;
        }
    }
}
