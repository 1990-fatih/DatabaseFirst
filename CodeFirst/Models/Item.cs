using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    public class Item
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Bitte eine Beschreibung ..")]
        [MaxLength(70)]
        [Display(Name="Beschreibung")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Bitte eine Geschäft ..")]
        [MaxLength(30)]
        [Display(Name = "Geschäft")]
        public string? Shop { get; set; }
    }
}
