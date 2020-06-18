using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoHospital.Models.FluentMap
{
    public class ExameMap
    {
        public ExameMap(ModelBuilder builder)
        {
            builder.Entity<Exame>(exame =>
            {
                exame.ToTable("Exames");
                exame.HasKey(ex => ex.Id);
                exame.Property(e => e.Id).ValueGeneratedOnAdd();
                exame.Property(ex => ex.Nome).IsRequired().HasColumnType("varchar(26)");
                exame.Property(ex => ex.Descricao).HasColumnType("varchar(100)");
                exame.Property(ex => ex.Custo).IsRequired().HasColumnType("decimal(5,2)");
                exame.Property(ex => ex.SexoPaciente).IsRequired().HasColumnType("varchar(9)");
                exame.Property(ex => ex.IdadePaciente).IsRequired().HasColumnType("varchar(15)");
                exame.Property(ex => ex.Parametro).IsRequired().HasColumnType("decimal(5,2)");
                exame.Property(ex => ex.ValorMinimo).IsRequired().HasColumnType("decimal(5,2)");
                exame.Property(ex => ex.ValorMaximo).IsRequired().HasColumnType("decimal(5,2)");
            });
        }
    }
}
