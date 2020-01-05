using System.ComponentModel.DataAnnotations;

namespace BodyProgress.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
