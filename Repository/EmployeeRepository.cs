using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentOneTOManyRelation.Data;
using StudentOneTOManyRelation.Entities;
using StudentOneTOManyRelation.Repository.Interface;

namespace StudentOneTOManyRelation.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> FindAsync(long id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task FlushAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Create(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
        }

        public void Update(Employee employee)
        {
            _context.Employees.Update(employee);
        }

        public void Remove(Employee employee)
        {
            _context.Employees.Remove(employee);
        }
    }
}