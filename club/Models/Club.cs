using System.ComponentModel.DataAnnotations;


namespace club.Models
{
    public class Club
    {
        public int Id { get; set; }
        [Display(Name = "Nom club")]
        [Required]
        public string Nom { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Creation")]
        [Required]
        public DateTime Date_creation { get; set; }
        [Required]
        public int LocaleId { get; set; }
        public virtual Locale? Locale { get; set; }
        public virtual ICollection<Activite>? Activites { get; set; }

     

    }
}
