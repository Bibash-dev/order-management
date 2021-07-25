using System.Threading.Tasks;
using StudentOneTOManyRelation.dto;
using StudentOneTOManyRelation.Entities;

namespace StudentOneTOManyRelation.Service.Interface
{
    public interface IEmployeeService
    {
        Task Create(EmployeeDto dto);
        Task Update(Employee employee,EmployeeDto dto);
        Task Remove(Employee employee);
    }
}