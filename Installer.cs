using Microsoft.Extensions.DependencyInjection;
using StudentOneTOManyRelation.Repository;
using StudentOneTOManyRelation.Repository.Interface;
using StudentOneTOManyRelation.Service;
using StudentOneTOManyRelation.Service.Interface;

namespace StudentOneTOManyRelation
{
    public static class Installer
    {
        public static void UseServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>()
                .AddScoped<IEmployeeRepository, EmployeeRepository>()
                .AddScoped<IDepartmentRepository, DepartmentRepository>()
                .AddScoped<IDepartmentService, DepartmentService>()
                .AddScoped<IOrderRepository, OrderRepository>()
                .AddScoped<IOrderService, OrderService>();
        }

        public static void UseRepos(this IServiceCollection services)
        {
        }
    }
}