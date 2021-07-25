using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentOneTOManyRelation.Data;
using StudentOneTOManyRelation.Entities;
using StudentOneTOManyRelation.Repository.Interface;

namespace StudentOneTOManyRelation.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> GetAllAsync()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department> FindAsync(long id)
        {
            return await _context.Departments.FindAsync(id);
        }

        public async Task FlushAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Create(Department department)
        {
            await _context.Departments.AddAsync(department);
        }

        public void Update(Department department)
        {
            _context.Departments.Update(department);
        }

        public void Remove(Department department)
        {
            _context.Departments.Remove(department);
        }

       
    }
}