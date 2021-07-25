using System.Threading.Tasks;
using System.Transactions;
using StudentOneTOManyRelation.dto;
using StudentOneTOManyRelation.Entities;
using StudentOneTOManyRelation.Repository.Interface;
using StudentOneTOManyRelation.Service.Interface;

namespace StudentOneTOManyRelation.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }


        public async Task Create(DepartmentDto dto)
        {
            using var tsc = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var department = new Department()
            {
                Name = dto.Name
            };
            await _departmentRepository.Create(department);
            await _departmentRepository.FlushAsync();
            tsc.Complete();
        }

        public async Task Update(Department department, DepartmentDto dto)
        {
            using var tsc = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            department.Name = dto.Name;
            _departmentRepository.Update(department);
            await _departmentRepository.FlushAsync();
            tsc.Complete();
        }

        public async Task Remove(Department department)
        {
            using var tsc = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            _departmentRepository.Remove(department);
            await _departmentRepository.FlushAsync();
            tsc.Complete();
        }
    }
}