using ShopTLA.Models.Domain;

namespace ShopTLA.Services.Employees
{
    public interface IEmployeesService
    {
        public Task<bool> AddEmployee(Employee employee);
        public Task<List<Employee>> GetAllEmployee(string token);
    }
}
