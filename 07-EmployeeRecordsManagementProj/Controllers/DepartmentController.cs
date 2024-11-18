using _07_EmployeeRecordsManagementProj.BLL.Contracts;
using _07_EmployeeRecordsManagementProj.DAL.Contracts;
using _07_EmployeeRecordsManagementProj.EntityModels;
using _07_EmployeeRecordsManagementProj.ViewModels.DepartmentVM;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace _07_EmployeeRecordsManagementProj.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IUnitManager _unitManager;
        private readonly IUnitRepository _unitRepository;
        private readonly IMapper _mapper;
        public DepartmentController(IUnitManager unitManager, IUnitRepository unitRepository, IMapper mapper)
        {
            this._unitManager = unitManager;
            this._unitRepository = unitRepository;
            this._mapper = mapper;
        }
        public async Task<IActionResult> Index(string text)
        {
            ViewBag.Message = text;
            IEnumerable<Department> departments = await _unitRepository.departmentRepository.GetAllAsync();
            IEnumerable<DepartmentCreateViewModel> departmentVM = _mapper.Map<IEnumerable<DepartmentCreateViewModel>>(departments);
            return View(departmentVM);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(DepartmentCreateViewModel departmentVM)
        {
            if (!ModelState.IsValid)
            {
                return View(departmentVM);
            }
            Department department = _mapper.Map<Department>(departmentVM);
            await _unitRepository.departmentRepository.AddAsync(department);
            bool isAdded = await _unitRepository.SaveChangesAsync();
            if (isAdded)
            {
                ViewBag.Message = "Department has been added successfully";
            }
            else
            {
                ViewBag.Message = "Sorry! Department hasn't been added";
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Department department = await _unitRepository.departmentRepository.GetByIdAsync(id);
            DepartmentCreateViewModel departmentVM = _mapper.Map<DepartmentCreateViewModel>(department);
            if (department != null)
            {
                return View(departmentVM);
            }
            ViewBag.Message = "Sorry! There is no department found";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(DepartmentCreateViewModel departmentVM)
        {
            if (!ModelState.IsValid)
            {
                return View(departmentVM);
            }
            Department department = _mapper.Map<Department>(departmentVM);
            _unitRepository.departmentRepository.Update(department);
            bool isUpdated = await _unitRepository.SaveChangesAsync();
            if (isUpdated)
            {
                return RedirectToAction("Index", "Department");
            }
            ViewBag.Message = "Sorry! information hasn't been updated";
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Department department = await _unitRepository.departmentRepository.GetByIdAsync(id);
            bool isRemoved = false;
            if (department != null)
            {
                _unitRepository.departmentRepository.Remove(department);
                isRemoved = await _unitRepository.SaveChangesAsync();
            }
            if (isRemoved)
            {
                return RedirectToAction("Index", "Department");
            }
            return RedirectToAction("Index", "Department", new { text = "Sorry! department hasn't been removed" });
        }
    }
}
