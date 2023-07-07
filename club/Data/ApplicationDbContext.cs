using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using club.Models;

namespace club.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<club.Models.Membre> Membre { get; set; }
        public DbSet<club.Models.Responsable> Responsable { get; set; }
        public DbSet<club.Models.Activite> Activite { get; set; }
        public DbSet<club.Models.Club> Club { get; set; }
        public DbSet<club.Models.Locale> Locale { get; set; }
        public DbSet<club.Models.Reservation> Reservation { get; set; }
    }
}