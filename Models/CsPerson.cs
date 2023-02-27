using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Models
{
    public class CsPerson:BaseModel
    {
        [Key]
        public int CsPersonId { get; set; }

        [Required]
        [DisplayName("CS Person Name")]
        [MaxLength(100), MinLength(2)]
        public string? CsPersonName { get; set; }

        public OrderMaster? OrderMaster { get; set; }
    }
}
