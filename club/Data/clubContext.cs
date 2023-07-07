using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using club.Models;

namespace club.Data
{
    public class clubContext : DbContext
    {
        public clubContext (DbContextOptions<clubContext> options)
            : base(options)
        {
        }

        public DbSet<club.Models.Club> Club { get; set; } = default!;

        public DbSet<club.Models.Membre> Membre { get; set; }

        public DbSet<club.Models.Locale> Locale { get; set; }

        public DbSet<club.Models.Activite> Activite { get; set; }

        public DbSet<club.Models.Responsable> Responsable { get; set; }
    }
}
