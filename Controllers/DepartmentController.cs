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
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IDepartmentService _departmentService;
        private readonly INotyfService _notify;

        public DepartmentController(IDepartmentRepository departmentRepository, IDepartmentService departmentService,
            INotyfService notify)
        {
            _departmentRepository = departmentRepository;
            _departmentService = departmentService;
            _notify = notify;
        }

        [HttpGet]
        public async Task<IActionResult> Index() => View(await _departmentRepository.GetAllAsync());


        [HttpGet]
        public IActionResult New()
        {
            return View(new DepartmentVm());
        }

        [HttpPost]
        public async Task<IActionResult> New(DepartmentVm vm)
        {
            try
            {
                var dto = new DepartmentDto()
                {
                    Name = vm.Name,
                };

                await _departmentService.Create(dto);
                _notify.Success("Department created");
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
            var department = await _departmentRepository.FindAsync(id);
            var vm = new DepartmentVm()
            {
                Name = department.Name,
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(long id, DepartmentVm vm)
        {
            try
            {
                var department = await _departmentRepository.FindAsync(id);
                var dto = new DepartmentDto()
                {
                    Name = vm.Name,
                };
                await _departmentService.Update(department, dto);
                _notify.Success("Department edited");
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
                var department = await _departmentRepository.FindAsync(id);
                await _departmentService.Remove(department);
                _notify.Success("Department Deleted");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                _notify.Error(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }
[HttpGet]
        public async Task<IActionResult> Details(long id) => View(await _departmentRepository.FindAsync(id));
    }
}