using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OMS.Models
{
    public class SubMenu : BaseModel
    {
        [Key]
        public int SubMenuId { get; set; }

        [DisplayName("Main Menu")]
        [ForeignKey("MainMenu")]
        public int MainMenuId { get; set; }
        public MainMenu? MainMenu { get; set; }

        [Required]
        [DisplayName("Sub Menu Name")]
        [MaxLength(20), MinLength(2)]
        public string? SubMenuName { get; set; }

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
    }
}
