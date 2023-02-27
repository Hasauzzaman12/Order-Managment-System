using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Models
{
    public class OrderMaster:BaseModel
    {
        [Key]
        public int OrderMasterId { get; set; }

        [DisplayName("Buyer Name")]
        [ForeignKey("Buyer")]
        public int BuyerId { get; set; }
        public Buyer? Buyer { get; set; }

        [DisplayName("Brand Name")]
        [ForeignKey("Brand")]
        public int BrandId { get; set; }
        public Brand? Brand { get; set; }

        [DisplayName("Customer Name")]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        [DisplayName("CS Name")]
        [ForeignKey("CsPerson")]
        public int CsPersonId { get; set; }
        public CsPerson? CsPerson { get; set; }

        [DisplayName("Is Nominated")]
        public bool IsNominated { get; set; }

        [DisplayName("Sales Name")]
        [ForeignKey("SalesPerson")]
        public int SalesPersonId { get; set; }
        public SalesPerson? SalesPerson { get; set; }
        
        [DisplayName("Order Type")]
        [ForeignKey("OrderType")]
        public int OrderTypeId { get; set; }
        public OrderType? OrderType { get; set; }

        [Required]
        [DisplayName("Customer Ref.")]
        [MaxLength(150), MinLength(2)]
        public string? CustomerRef { get; set; }
        
        [Required]
        [DisplayName("Style Ref.")]
        [MaxLength(150), MinLength(2)]
        public string? StyleRef { get; set; }
        
        [DisplayName("Season")]
        [MaxLength(150)]
        public string? Season { get; set; }
        
        [DisplayName("Country of Origin")]
        [MaxLength(150)]
        public string? CountryofOrigin { get; set; }
        
        [DisplayName("Contact Person")]
        [MaxLength(150)]
        public string? ContactPerson { get; set; }
        
        [DisplayName("Contact No.")]
        [MaxLength(20)]
        public string? ContactNo { get; set; }

        public OrderDetails? OrderDetails { get; set; }
    }
}
