using System.ComponentModel.DataAnnotations;


namespace club.Models
{
    public class Responsable
    {
        public int Id { get; set; }
        [Required]
        public string Titre { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date Debut")]
        public DateTime Date_Debut { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Fin")]
        public DateTime? Date_Fin { get; set; }

        [Display(Name = "Membre")]
        [Required]
        public int MembreId { get; set; }

        public virtual Membre? Membre { get; set; }

    }
}
