using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OMS.Models
{
    public class Employee:BaseModel
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [DisplayName("Employee ID")]
        [MaxLength(10), MinLength(2)]
        public String? EmpIdCardNo { get; set; }

        [Required]
        [DisplayName("Employee Name")]
        [MaxLength(100), MinLength(2)]
        public string? EmployeeName { get; set; }

        [Required]
        [DisplayName("Joining Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime JoiningDate { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public Company? Company { get; set; }

        [ForeignKey("Designation")]
        public int DesignationId { get; set; }
        public Designation? Designation { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }

        [Required]
        [DisplayName("Date Of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [DisplayName("Address")]
        [MaxLength(200), MinLength(2)]
        public string? Address { get; set; }

        [Required]
        [DisplayName("Email")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DisplayName("Mobile")]
        [MaxLength(20), MinLength(2)]
        public string? Mobile { get; set; }
    }
}
