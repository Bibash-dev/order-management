using System;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using StudentOneTOManyRelation.dto;
using StudentOneTOManyRelation.Repository.Interface;
using StudentOneTOManyRelation.Service.Interface;
using StudentOneTOManyRelation.ViewModel;

namespace StudentOneTOManyRelation.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderService _orderService;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly INotyfService _notify;

        public OrderController(IOrderRepository orderRepository, IOrderService orderService,
            IDepartmentRepository departmentRepository, IEmployeeRepository employeeRepository, INotyfService notify)
        {
            _orderRepository = orderRepository;
            _orderService = orderService;
            _departmentRepository = departmentRepository;
            _employeeRepository = employeeRepository;
            _notify = notify;
        }

        public async Task<IActionResult> Index()
            => View(await _orderRepository.GetAllAsync());

        [HttpGet]
        public async Task<IActionResult> New()
        {
            var vm = new OrderVm();
            await LoadDropdown(vm);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> New(OrderVm vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    await LoadDropdown(vm);
                    return View(vm);
                }

                var dto = new OrderDto()
                {
                    Name = vm.Name,
                    Price = vm.Price,
                    Product = vm.Product,
                    Employee = await _employeeRepository.FindAsync(vm.EmployeeId),
                    Department = await _departmentRepository.FindAsync(vm.DepartmentId),
                };
                await _orderService.Create(dto);
                _notify.Success("Order Created");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                _notify.Error(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(long id)
        {
            try
            {
                var order = await _orderRepository.FindAsync(id);
                var vm = new OrderVm()
                {
                    Name = order.Name,
                    Price = order.Price,
                    Product = order.Product,
                };
                await LoadDropdown(vm);
                return View(vm);
            }
            catch (Exception e)
            {
                _notify.Error(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(long id, OrderVm vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    await LoadDropdown(vm);
                    return View(vm);
                }

                var order = await _orderRepository.FindAsync(id);
                var dto = new OrderDto()
                {
                    Name = vm.Name,
                    Product = vm.Product,
                    Price = vm.Price,
                    Department = await _departmentRepository.FindAsync(vm.DepartmentId),
                    Employee = await _employeeRepository.FindAsync(vm.EmployeeId),
                        
                };
                await _orderService.Update(order, dto);
                _notify.Success("order Edited");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                _notify.Error(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var order = await _orderRepository.FindAsync(id);
                await _orderService.Remove(order);
                _notify.Success("Order deleted");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                _notify.Error(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(long id)
            => View(await _orderRepository.FindAsync(id));

        private async Task LoadDropdown(OrderVm vm)
        {
            vm.Departments = await _departmentRepository.GetAllAsync();
            vm.Employees = await _employeeRepository.GetAllAsync();
        }
    }
}