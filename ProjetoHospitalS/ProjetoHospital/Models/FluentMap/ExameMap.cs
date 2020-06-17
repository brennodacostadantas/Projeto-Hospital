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
                exame.Property(exa => exa.Id).ValueGeneratedOnAdd();
                exame.Property(ex => ex.Nome).IsRequired();
                exame.Property(ex => ex.Descricao).IsRequired();
                exame.Property(ex => ex.Valor).IsRequired().HasColumnType("decimal(5,2)");
            });
        }
    }
}
