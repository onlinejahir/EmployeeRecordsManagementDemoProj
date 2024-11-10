using _07_EmployeeRecordsManagementProj.EntityModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _07_EmployeeRecordsManagementProj.ViewModels.EmployeeVM
{
    public class EmployeeCreateViewModel
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage ="First name is required."), Display(Name ="First Name")]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Last name is required."), Display(Name ="Last Name")]
        [StringLength(100)]
        public string LastName { get; set; }
        [Required(ErrorMessage ="Date of Birth is required"), Display(Name ="Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage ="Gender is required")]
        public string Gender { get; set; }
        [Required(ErrorMessage ="Email address is required"), EmailAddress(ErrorMessage ="Invalid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Phone number is required"), Phone(ErrorMessage ="Invalid phone number")]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required, Display(Name ="Is Active")]
        public bool IsActive { get; set; }

        //Relationship with department         
        public int DepartmentId { get; set; } //Foreign key for Department        
    }
}
