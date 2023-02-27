using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Models
{
    public class Brand:BaseModel
    {
        [Key]
        public int BrandId { get; set; }

        [Required]
        [DisplayName("Brand Name")]
        [MaxLength(100), MinLength(2)]
        public string? BrandName { get; set; }

        public OrderMaster? OrderMaster { get; set; }
    }
}
