using System.Collections.Generic;
using System.Threading.Tasks;
using StudentOneTOManyRelation.Entities;

namespace StudentOneTOManyRelation.Repository.Interface
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetAllAsync();
        Task<Department> FindAsync(long id);
        Task FlushAsync();
        Task Create(Department department);
        void Update(Department department);
        void Remove(Department department);
    }
}