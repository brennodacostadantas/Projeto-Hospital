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
                plano.HasKey(pl => pl.Id);
                plano.Property(p => p.Id).ValueGeneratedOnAdd();
                plano.Property(pl => pl.Nome).IsRequired();
                plano.Property(pl => pl.Sigla).IsRequired().HasColumnType("varchar(5)");
            });
        }
    }
}
