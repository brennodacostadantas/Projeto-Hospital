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
                estado.ToTable("Estados");
                estado.HasKey(e => e.Id);
                estado.Property(es => es.Id).ValueGeneratedNever();
                estado.Property(e => e.Sigla).IsRequired();
                estado.Property(e => e.Nome).IsRequired();
            });
        }
    }
}
