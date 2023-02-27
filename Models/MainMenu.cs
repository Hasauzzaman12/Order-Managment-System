using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OMS.Models
{
    public class MainMenu:BaseModel
    {
        [Key]
        public int MainMenuId { get; set; }

        [DisplayName("Module")]
        [ForeignKey("Module")]
        public int ModuleId { get; set; }
        public Module? Module { get; set; }

        [Required]
        [DisplayName("Main Menu Name")]
        [MaxLength(20), MinLength(2)]
        public string? MainMenuName { get; set; }

        [Required]
        [DisplayName("Description")]
        [MaxLength(200), MinLength(2)]
        public string? Description { get; set; }

        [Required]
        [DisplayName("Area Name")]
        [MaxLength(30), MinLength(2)]
        public string? AreaName { get; set; }

        [Required]
        [DisplayName("Action Name")]
        [MaxLength(30), MinLength(2)]
        public string? ActionName { get; set; }

        [Required]
        [DisplayName("Controller Name")]
        [MaxLength(30), MinLength(2)]
        public string? ControllerName { get; set; }

        public ICollection<SubMenu>? SubMenus { get; set; }
    }
}
