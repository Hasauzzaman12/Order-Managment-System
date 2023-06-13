using OMS.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OMS.ViewModel
{
    public class MenuViewModel:BaseModel
    {
       public IEnumerable<Module> Modules { get; set; }
       public IEnumerable<Menu> Menus { get; set; }

        public int MenuId { get; set; }

        [DisplayName("Module")]
        [ForeignKey("Module")]
        public int ModuleId { get; set; }
        public Module? Module { get; set; }

        [DisplayName("ParentId")]
        public int ParentId { get; set; }

        [Required]
        [DisplayName("Menu Name")]
        [MaxLength(20), MinLength(2)]
        public string? MenuName { get; set; }

        [Required]
        [DisplayName("Description")]
        [MaxLength(200), MinLength(2)]
        public string? Description { get; set; }

        [Required]
        [DisplayName("Area Name")]
        [MaxLength(30), MinLength(2)]
        public string? AreaName { get; set; }

        [DisplayName("Has Sub Menu")]
        public bool? HasSubMenu { get; set; }

        [DisplayName("Controller Name")]
        [MaxLength(30), MinLength(2)]
        public string? ControllerName { get; set; }

        [DisplayName("Action Name")]
        [MaxLength(30), MinLength(2)]
        public string? ActionName { get; set; }
    }
}
