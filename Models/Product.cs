using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace OMS.Models
{
    public class Product:BaseModel
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [DisplayName("Product Name")]
        [MaxLength(100), MinLength(2)]
        public string? ProductName { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required]
        [DisplayName("Product Size")]
        [MaxLength(50), MinLength(2)]
        public string? ProductSize { get; set; }
        
        [Required]
        [DisplayName("Product Color")]
        [MaxLength(50), MinLength(2)]
        public string? ProductColor { get; set; }

        [ForeignKey("UoM")]
        public int UoMId { get; set; }
        public UoM? UoM { get; set; }

        [Required]
        [DisplayName("Unit Price")]
        public double UnitPrice { get; set; }

        [Required]
        [DisplayName("Product Image")]
        public string? ProductImage { get; set; }

        public OrderDetails? OrderDetails { get; set; }
    }
}
