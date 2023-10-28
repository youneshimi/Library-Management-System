using System.Data.Entity;
using System;



    public class libContext : DbContext
    {
        public DbSet<Livre> Livres { get; set; }
        public DbSet<Abonne> Abonnes { get; set; }
        public DbSet<Emprunt> Emprunts { get; set; }
    }

