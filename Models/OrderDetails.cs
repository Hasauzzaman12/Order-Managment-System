using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Models
{
    public class OrderDetails:BaseModel
    {
        [Key]
        public int OrderDetailsId { get; set; }

        [ForeignKey("OrderMaster")]
        public int OrderMasterId { get; set; }
        public OrderMaster? OrderMaster { get; set; }

        [Required]
        [DisplayName("Product")]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        [DisplayName("Fabric Content")]
        [MaxLength(250)]
        public string? FabricContent { get; set; }
        
        [DisplayName("Size")]
        [MaxLength(150)]
        public string? Size { get; set; }
        
        [DisplayName("Color")]
        [MaxLength(50)]
        public string? Color { get; set; }
        
        [DisplayName("Barcode")]
        [MaxLength(150)]
        public string? Barcode { get; set; }
        
        [DisplayName("UoM")]
        [MaxLength(50)]
        public string? UoM { get; set; }
        
        [DisplayName("QTY.")]
        [MaxLength(50)]
        public string? QTY { get; set; }

    }
}
