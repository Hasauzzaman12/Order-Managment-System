using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Models
{
    public class SalesPerson:BaseModel
    {
        [Key]
        public int SalesPersonId { get; set; }

        [Required]
        [DisplayName("Sales Person Name")]
        [MaxLength(100), MinLength(2)]
        public string? SalesPersonName { get; set; }

        public OrderMaster? OrderMaster { get; set; }
    }
}
