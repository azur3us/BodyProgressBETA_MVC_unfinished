using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BodyProgress.Models;

namespace BodyProgress.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public List<BodyPart> BodyParts { get; set; }

        
    }
}
