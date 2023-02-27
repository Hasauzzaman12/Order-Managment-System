using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Models
{
    public class OrderType:BaseModel
    {
        [Key]
        public int OrderTypeId { get; set; }

        [Required]
        [DisplayName("Order Type")]
        [MaxLength(100), MinLength(2)]
        public string? OrderTypeName { get; set; }

        public OrderMaster? OrderMaster { get; set; }
    }
}
