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
    public class Module:BaseModel
    {
        [Key]
        public int ModuleId { get; set; }

        [Required]
        [DisplayName("Module Name")]
        [MaxLength(100), MinLength(2)]
        public string? ModuleName { get; set; }

        [Required]
        [DisplayName("Description")]
        [MaxLength(250), MinLength(2)]
        public string? Description { get; set; }

        [Required]
        [DisplayName("Module Serial")]
        public int ModuleSerial { get; set; }

        [Required]
        [DisplayName("Area Name")]
        [MaxLength(100), MinLength(2)]
        public string? AreaName { get; set; }

        [DisplayName("Controller Name")]
        [MaxLength(100), MinLength(2)]
        public string ControllerName { get; set; }

        [DisplayName("View Name")]
        [MaxLength(250), MinLength(2)]
        public string ViewName { get; set; }

        [NotMapped]
        public IFormFile ModuleImage { get; set; }

        [DisplayName("Image Path")]
        public string? ImagePath { get; set; }

        public ICollection<MainMenu>? MainMenus { get; set; }
    }
}