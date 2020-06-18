using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoHospital.Models.FluentMap
{
    public class EstadoMap
    {
        public EstadoMap(ModelBuilder builder)
        {
            builder.Entity<Estado>(estado =>
            {
                estado.ToTable("Estado");
                estado.HasKey(e => e.Id);
                estado.Property(a => a.Id).ValueGeneratedOnAdd();
                estado.Property(e => e.Sigla).IsRequired().HasColumnType("char(2)");
                estado.Property(e => e.Nome).IsRequired().HasColumnType("varchar(100)");
            });
        }
    }
}
