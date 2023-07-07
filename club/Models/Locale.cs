using System.ComponentModel.DataAnnotations;


namespace club.Models
{
    public class Locale
    {
        public int Id { get; set; }
        [Required]
        public String Classe { get; set; }

        [Required]
        public virtual ICollection<Club>? Clubs { get; set; }
    }
}
