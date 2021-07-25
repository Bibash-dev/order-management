using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentOneTOManyRelation.Entities;

namespace StudentOneTOManyRelation.ViewModel
{
    public class OrderVm
    {
        public string Name { get; set; }
        public string Product { get; set; }
        public double Price { get; set; }
        [DisplayName("Employee")]
        public long EmployeeId { get; set; }
        [DisplayName("Department")]
        public long DepartmentId { get; set; }
        public IEnumerable<Department> Departments { get; set; } = new List<Department>();
        public IEnumerable<Employee> Employees { get; set; } = new List<Employee>();

        public SelectList DepartmentOptions() => new SelectList(Departments, nameof(Department.Id), nameof(Department.Name), DepartmentId);

        public SelectList EmployeeOptions() => new SelectList(Employees,nameof(Employee.Id),nameof(Employee.Name),EmployeeId);
    }
}