using System.ComponentModel.DataAnnotations;

namespace club.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime timeDeb { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime timeFin { get; set; }
        [Required]
        public string reservedBy { get; set; }
        [Required]
        public string clubName { get; set; }


    }
}
