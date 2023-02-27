using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OMS.Models
{
    public class Company : BaseModel
    {
        [Key]
        public int CompanyId { get; set; }
        
        [Required]
        [DisplayName("Company Name")]
        [MaxLength(100), MinLength(2)]
        public string? CompanyName { get; set; }

        [Required]
        [DisplayName("Contact Person")]
        [MaxLength(100), MinLength(2)]
        public string? ContactPerson { get; set; }

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
