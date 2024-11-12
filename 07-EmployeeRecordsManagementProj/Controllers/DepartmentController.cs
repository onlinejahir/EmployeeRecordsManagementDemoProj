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
        public async Task<IActionResult> Index()
        {
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
        public async Task<IActionResult> Edit(DepartmentCreateViewModel id)
        {
            return View();
        }
    }
}
