using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OMS.Models

{
    public class Department:BaseModel
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        [DisplayName("Department Name")]
        [MaxLength(100), MinLength(2)]
        public string? DepartmentName { get; set; }

        public Employee? Employee { get; set; }

    }
}
