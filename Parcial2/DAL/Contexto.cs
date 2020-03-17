using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Parcial2.Entidades;

namespace Parcial2.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Llamada> Llamadas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source = ParcialDB.db");
        }
    }
}
