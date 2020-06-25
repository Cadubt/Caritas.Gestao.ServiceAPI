using Caritas.Gestao.ServiceAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caritas.Gestao.ServiceAPI.Data
{
    public class CaritasContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer("CaritasDev");
        }
    }
}
