using _07_EmployeeRecordsManagementProj.BLL.Contracts;
using _07_EmployeeRecordsManagementProj.DAL.Contracts;
using _07_EmployeeRecordsManagementProj.EntityModels;
using _07_EmployeeRecordsManagementProj.ViewModels.EmployeeVM;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _07_EmployeeRecordsManagementProj.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitManager _unitManager;
        private readonly IUnitRepository _unitRepository;
        private readonly IMapper _mapper;
        public EmployeeController(IUnitManager unitManager, IUnitRepository unitRepository, IMapper mapper)
        {
            this._unitManager = unitManager;
            this._unitRepository = unitRepository;
            this._mapper = mapper;
        }
        public async Task<IActionResult> Index(string text, string searchString, string sortOrder)
        {
            ViewBag.Message = text;
            List<Employee> employees = (await _unitRepository.employeeRepository.GetAllAsync()).ToList();
            //search functionality
            if (!string.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(e => e.FirstName.Contains(searchString) || e.LastName.Contains(searchString)).ToList();
            }

            //sorting
            ViewData["NameSortParam"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateOfBirthSortParam"] = sortOrder == "date_asc" ? "date_desc" : "date_asc";
            ViewData["IsActiveSortParam"] = sortOrder == "isactive_asc" ? "isactive_desc" : "isactive_asc";
            switch (sortOrder)
            {
                case "name_desc":
                    employees = employees.OrderByDescending(e => e.FirstName).ToList();
                    break;
                case "date_asc":
                    employees = employees.OrderBy(e => e.DateOfBirth).ToList();
                    break;
                case "date_desc":
                    employees = employees.OrderByDescending(e => e.DateOfBirth).ToList();
                    break;
                case "isactive_asc":
                    employees = employees.OrderBy(e => e.IsActive).ToList();
                    break;
                case "isactive_desc":
                    employees = employees.OrderByDescending(e => e.IsActive).ToList();
                    break;

                default:
                    employees = employees.OrderBy(e => e.FirstName).ToList();
                    break;
            }
            List<EmployeeCreateViewModel> employeeVM = _mapper.Map<List<EmployeeCreateViewModel>>(employees);
            return View(employeeVM);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var departments = await _unitRepository.departmentRepository.GetAllAsync();
            ViewBag.Departments = new SelectList(departments, "DepartmentId", "DepartmentName");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(EmployeeCreateViewModel employeeVM)
        {
            if (!ModelState.IsValid)
            {
                return View(employeeVM);
            }
            Employee employee = _mapper.Map<Employee>(employeeVM);
            await _unitRepository.employeeRepository.AddAsync(employee);
            bool isAdded = await _unitRepository.SaveChangesAsync();
            if (isAdded)
            {
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                ViewBag.Message = "Sorry! employee hasn't been added";
                return View();
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            List<Department> departments = (await _unitRepository.departmentRepository.GetAllAsync()).ToList();
            ViewBag.Departments = new SelectList(departments, "DepartmentId", "DepartmentName");
            Employee employee = await _unitRepository.employeeRepository.GetByIdAsync(id);
            EmployeeCreateViewModel employeeVM = _mapper.Map<EmployeeCreateViewModel>(employee);
            if (employee != null)
            {
                return View(employeeVM);
            }
            else
            {
                ViewBag.Message = "Sorry! There is no employee information from this id";
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeCreateViewModel employeeVM)
        {
            if (!ModelState.IsValid)
            {
                return View(employeeVM);
            }
            Employee employee = _mapper.Map<Employee>(employeeVM);
            _unitRepository.employeeRepository.Update(employee);
            bool isUpdated = await _unitRepository.SaveChangesAsync();
            if (isUpdated)
            {
                return RedirectToAction("Index", "Employee");
            }
            ViewBag.Message = "Sorry! information hasn't been updated";
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Employee employee = await _unitRepository.employeeRepository.GetByIdAsync(id);
            bool isReomved = false;
            if (employee != null)
            {
                _unitRepository.employeeRepository.Remove(employee);
                isReomved = await _unitRepository.SaveChangesAsync();
            }
            if (isReomved)
            {
                return RedirectToAction("Index", "Employee");
            }
            return RedirectToAction("Index", "Employee", new { text = "Sorry, employee hasn't been removed" });
        }
    }
}
