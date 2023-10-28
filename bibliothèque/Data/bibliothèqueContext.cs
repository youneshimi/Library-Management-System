using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace bibliothèque.Data
{
    public class bibliothèqueContext : DbContext
    {
        public bibliothèqueContext (DbContextOptions<bibliothèqueContext> options)
            : base(options)
        {
        }

        public DbSet<Abonne> Abonne { get; set; } = default!;

        public DbSet<Livre>? Livre { get; set; }

        public DbSet<Emprunt>? Emprunt { get; set; }
    }
}
