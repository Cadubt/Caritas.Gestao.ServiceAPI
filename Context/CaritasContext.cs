using Caritas.Gestao.ServiceAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caritas.Gestao.ServiceAPI.Context
{
    public class CaritasContext : DbContext
    {
        public CaritasContext(DbContextOptions<CaritasContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }

        //public DbSet<Sheltered> Sheltereds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure default schema
            //modelBuilder.HasDefaultSchema("Ordering");
            modelBuilder.Entity<User>().ToTable("Users","usr");
            //modelBuilder.Entity<Standard>().ToTable("StandardInfo", "dbo");
        }
    }
}
