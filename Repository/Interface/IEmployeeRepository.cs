using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using StudentOneTOManyRelation.Entities;

namespace StudentOneTOManyRelation.Repository.Interface
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllAsync();
        Task<Employee> FindAsync(long id);
        Task  FlushAsync();
        Task Create(Employee employee);
         void Update(Employee employee);
        void Remove(Employee employee);
    }
}