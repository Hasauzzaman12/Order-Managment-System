using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OMS.Models
{
    public class Designation:BaseModel
    {
        [Key]
        public int DesignationId { get; set; }

        [Required]
        [DisplayName("Designation Name")]
        [MaxLength(100), MinLength(2)]
        public string? DesignationName { get; set; }

    }
}
