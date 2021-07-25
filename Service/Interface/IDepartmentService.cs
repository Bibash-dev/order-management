using System.Collections.Generic;
using System.Threading.Tasks;
using StudentOneTOManyRelation.dto;
using StudentOneTOManyRelation.Entities;

namespace StudentOneTOManyRelation.Service.Interface
{
    public interface IDepartmentService
    {
        Task Create(DepartmentDto dto);
        Task Update(Department department,DepartmentDto dto);
        Task Remove(Department department);
        

    }
}