using System.ComponentModel.DataAnnotations;

namespace Portafolio.Models
{
    public class Emaildata
    {
        [Key]
        public int Id { get; set; }
        [Display(Name="Email")]
        public string Email { get; set; }
        [Display(Name ="Password")]
        public string Password { get; set; }
    }
}
