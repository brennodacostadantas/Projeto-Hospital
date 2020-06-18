using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoHospital.Models.FluentMap
{
    public class DiaSemanaMap
    {
        public DiaSemanaMap(ModelBuilder builder)
        {
            builder.Entity<DiaSemana>(diaSemana =>
            {
                diaSemana.ToTable("DiasSemanas");
                diaSemana.HasKey(d => d.Id);
                diaSemana.Property(a => a.Id).ValueGeneratedOnAdd();
                diaSemana.Property(d => d.Nome).IsRequired().HasColumnType("varchar(13)");
            });
        }
    }
}
