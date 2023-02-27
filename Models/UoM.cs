using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Models
{
    public class UoM:BaseModel
    {
        [Key]
        public int UoMId { get; set; }

        [Required]
        [DisplayName("UoM Name")]
        [MaxLength(100), MinLength(2)]
        public string? UoMName { get; set; }

        public Product? Product { get; set; }

    }
}
