using System.ComponentModel.DataAnnotations;

namespace _07_EmployeeRecordsManagementProj.EntityModels
{
    public class Department
    {
        public int DepartmentId { get; set; }
        [Required]
        public string DepartmentName { get; set; }

        //Relationship with employee
        public ICollection<Employee> Employees { get; set; } //Collection navigation property
        //public ICollection<Employee> Employees { get; set; } = new List<Employee>(); // Initialize collection
    }
}
