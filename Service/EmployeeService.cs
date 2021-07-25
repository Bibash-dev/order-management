using System.Threading.Tasks;
using System.Transactions;
using StudentOneTOManyRelation.dto;
using StudentOneTOManyRelation.Entities;
using StudentOneTOManyRelation.Repository.Interface;
using StudentOneTOManyRelation.Service.Interface;

namespace StudentOneTOManyRelation.Service
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task Create(EmployeeDto dto)
        {
            using var tsc = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var employee = new Employee()
            {
                Name = dto.Name,
            };
            await _employeeRepository.Create(employee);
            await _employeeRepository.FlushAsync();
            tsc.Complete();
        }

        public async Task Update(Employee employee, EmployeeDto dto)
        {
            using var tsc = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            employee.Name = dto.Name;
            _employeeRepository.Update(employee);
           await _employeeRepository.FlushAsync();
            tsc.Complete();
        }

        public async Task Remove(Employee employee)
        {
            using var tsc = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
          _employeeRepository.Remove(employee);
          await _employeeRepository.FlushAsync();
          tsc.Complete();

        }
    }
}