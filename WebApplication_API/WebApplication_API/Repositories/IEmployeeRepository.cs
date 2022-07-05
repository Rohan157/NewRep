using DataAccessLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication_API.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> Search(string name);
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int Id);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        Task<Employee> DeleteEmployee(int Id);
    }
}
