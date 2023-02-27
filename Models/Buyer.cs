using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Models
{
    public class Buyer : BaseModel
    {
        [Key]
        public int BuyerId { get; set; }

        [Required]
        [DisplayName("Buyer Name")]
        [MaxLength(100), MinLength(2)]
        public string? BuyerName { get; set; }

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

        public OrderMaster? OrderMaster { get; set; }
    }
}
