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

        [Required]
        [DisplayName("Controller Name")]
        [MaxLength(100), MinLength(2)]
        public string? Controller { get; set; }

        [Required]
        [DisplayName("View Name")]
        [MaxLength(250), MinLength(2)]
        public string? ViewName { get; set; }

        [DisplayName("Module Image")]
        public string? ModuleImagePath { get; set; }

        public ICollection<MainMenu>? MainMenus { get; set; }
    }
}
