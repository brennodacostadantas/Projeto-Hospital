using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoHospital.Models.FluentMap
{
    public class PlanoMap
    {
        public PlanoMap(ModelBuilder builder)
        {
            builder.Entity<Plano>(plano =>
            {
                plano.ToTable("Planos");
                plano.HasKey(p => p.Id);
                plano.Property(pl => pl.Id).ValueGeneratedOnAdd();
                plano.Property(p => p.Nome).IsRequired().HasColumnType("varchar(30)");
                plano.Property(p => p.Sigla).IsRequired().HasColumnType("varchar(9)");
            });
        }
    }
}
