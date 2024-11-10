using System.ComponentModel.DataAnnotations;

namespace _07_EmployeeRecordsManagementProj.ViewModels.DepartmentVM
{
    public class DepartmentCreateViewModel
    {
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Department name is required")]
        public string DepartmentName { get; set; }
    }
}
