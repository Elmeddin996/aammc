using System.ComponentModel.DataAnnotations;

namespace aammc.Areas.Manage.ViewModels
{
    public class AdminLoginViewModel
    {

        [Required]
        [MaxLength(20)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
