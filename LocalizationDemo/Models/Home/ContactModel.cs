using System.ComponentModel.DataAnnotations;

namespace LocalizationDemo.Models.Home
{
    public class ContactModel
    {
        [Required]
        [MaxLength(50)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        [Display(Name = "Comment")]
        public string Comment { get; set; }
    }
}
