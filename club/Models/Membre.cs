using System.ComponentModel.DataAnnotations;


namespace club.Models
{
    public class Membre
    {
        public int Id { get; set; }
        [Display(Name = "Nom Membre")]
        [Required]
        public string Nom { get; set; }
        [Display(Name = "Prenom Membre")]
        [Required]
        public string Prenom { get; set; }
        [Display(Name = "Télephone")]
        [Required]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "Ce champ doit comporter 8 chiffres ")]
        public string Tel { get; set; }
        [Display(Name = "Adresse Email")]
        [Required]
        [EmailAddress]  
        public string Email { get; set; }
        [Required]
        public string NomPrenom { get { return Prenom + " " + Nom; } }

        public virtual ICollection<Responsable>? Responsables { get; set; }

        public virtual ICollection<Activite>? Activites { get; set; }

    }
}