﻿using Microsoft.EntityFrameworkCore;
using PersonalClassroom.Database.Entities;

namespace PersonalClassroom.Database
{
    public class PcContext : DbContext
    {
        public PcContext() { }
        public PcContext(DbContextOptions options) : base(options) { }

        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<StudentPayment> StudentPayments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.UseNpgsql("Username=pc;Password=pc;Server=db;Database=personal_classroom");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentPayment>().HasKey(x => new { x.PaymentId, x.StudentId });
            modelBuilder.Entity<Level>().HasData(
                new Level { Id = 1, Symbol = "A1", Name = "Utilisateur élémentaire", Description = "Niveau introductif ou de découverte" },
                new Level { Id = 2, Symbol = "A2", Name = "Utilisateur élémentaire", Description = "Niveau intermédiaire ou usuel" },
                new Level { Id = 3, Symbol = "B1", Name = "Utilisateur indépendant", Description = "Niveau seuil" },
                new Level { Id = 4, Symbol = "B2", Name = "Utilisateur indépendant", Description = "Niveau avancé ou indépendant" },
                new Level { Id = 5, Symbol = "C1", Name = "Utilisateur expérimenté", Description = "Niveau autonome" },
                new Level { Id = 6, Symbol = "C2", Name = "Utilisateur expérimenté ", Description = "Niveau maîtrise" }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
