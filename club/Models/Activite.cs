using System.ComponentModel.DataAnnotations;


namespace club.Models
{
    public class Activite
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nom Activite")]
        public string Nom { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description de l'ctivite")]
        [Required]
        public string Description { get; set; }

        [Display(Name = "Club")]
        [Required]
        public int ClubId { get; set; }
        [Required]
        [Display(Name = "Membre")]
        public int MembreId { get; set; }
        public virtual Club? Club { get; set; }
        public virtual Membre? Membre { get; set; }


    }
}
