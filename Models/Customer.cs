using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Models;

namespace OMS.Models
{
    public class Customer:BaseModel
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [DisplayName("Customer Name")]
        [MaxLength(100), MinLength(2)]
        public string? CustomerName { get; set; }

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
