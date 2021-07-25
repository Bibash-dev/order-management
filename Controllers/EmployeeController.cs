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
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeService _employeeService;
        private readonly INotyfService _notify;

        public EmployeeController(IEmployeeRepository employeeRepository, IEmployeeService employeeService,INotyfService notify)
        {
            _employeeRepository = employeeRepository;
            _employeeService = employeeService;
            _notify = notify;
        }

        [HttpGet]
        public async Task<IActionResult> Index() => View(await _employeeRepository.GetAllAsync());


        [HttpGet]
        public IActionResult New()
        {
            return View(new EmployeeVm());
        }

        [HttpPost]
        public async Task<IActionResult> New(EmployeeVm vm)
        {
            try
            {
                var dto = new EmployeeDto()
                {
                    Name = vm.Name,
                };
                await _employeeService.Create(dto);
                _notify.Success("Employment created");
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
            var employee = await _employeeRepository.FindAsync(id);
            var vm = new EmployeeVm()
            {
                Name = employee.Name,
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(long id, EmployeeVm vm)
        {
            try
            {
                var employee = await _employeeRepository.FindAsync(id);
                var dto = new EmployeeDto()
                {
                    Name = vm.Name,
                };
                await _employeeService.Update(employee, dto);
                _notify.Success("Employee Edited");
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
                var employee = await _employeeRepository.FindAsync(id);
                await _employeeService.Remove(employee);
                _notify.Success("Deleted");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
               _notify.Error(e.Message);
               return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(long id) => View(await _employeeRepository.FindAsync(id));
    }
}