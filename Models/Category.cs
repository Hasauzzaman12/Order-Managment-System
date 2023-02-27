using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Models
{
    public class Category : BaseModel
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [DisplayName("Category Name")]
        [MaxLength(100), MinLength(2)]
        public string? CategoryName { get; set; }

        public Product? Product { get; set; }
    }
}
