using Microsoft.EntityFrameworkCore;
using PokeDex.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokeDex.Data
{
    public class PokeDexContext : DbContext
    {
        public DbSet<Creatures> Creatures { get; set; }
        public DbSet<Typing> Typing { get; set; }
        public DbSet<Creature_Types> Creature_Type { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var connectionString = "Data Source = .\\SQLExpress; Initial Catalog = Kanto";
            var connectionString = "Data Source = (localdb)\\ProjectsV13; Initial Catalog = PokeDex_Db_Dev";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Creature_Types>().HasNoKey();

            modelBuilder.Entity<Creature_Types>()
                .HasKey(ct => new { ct.CreatureId, ct.TypeId });

            modelBuilder.Entity<Creatures>()
                .Property(c => c.CreatureId)
                .ValueGeneratedOnAdd();

            //modelBuilder.Entity<Creature_Types>()
            //    .HasOne(ct => ct.Creatures)
            //    .WithMany(c => c.Creature_Types)
            //    .HasForeignKey(ct => ct.CreatureId);

            //modelBuilder.Entity<Creature_Types>()
            //    .HasOne(ct => ct.Typing)
            //    .WithMany(t => t.Creature_Types)
            //    .HasForeignKey(ct => ct.TypeId);
        }
    }
}
