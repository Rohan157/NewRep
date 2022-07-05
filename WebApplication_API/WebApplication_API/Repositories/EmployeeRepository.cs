using DataAccessLayer;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_API.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result = await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee> DeleteEmployee(int Id)
        {
            var result = await _context.Employees.Where(a => a.Id == Id).FirstOrDefaultAsync();
            if(result != null)
            {
                _context.Employees.Remove(result);
                await _context.SaveChangesAsync();
            }
            return null;
        }

        public async Task<Employee> GetEmployee(int Id)
        {
            return await _context.Employees.FirstOrDefaultAsync(a => a.Id == Id);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<IEnumerable<Employee>> Search(string name)
        {
            IQueryable<Employee> query = _context.Employees;
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(a => a.Name == name);
            }
            return await query.ToListAsync();
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await _context.Employees.FirstOrDefaultAsync(a => a.Id == employee.Id);
            if(result != null)
            {
                result.Name = employee.Name;
                result.City = employee.City;
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
