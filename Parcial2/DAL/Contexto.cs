using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Parcial2.DAL
{
    public class Contexto : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source = ParcialDB.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Productos>().HasData(new Productos { ProductoId = 1, Descripcion = "chocolate", Precio = 100 }); modelBuilder.Entity<Productos>().HasData(new Productos { ProductoId = 2, Descripcion = "cafe", Precio = 100 });

            //modelBuilder.Entity<Productos>().HasData(new Productos { ProductoId = 3, Descripcion = "arroz", Precio = 100 });

        }
    }
}
