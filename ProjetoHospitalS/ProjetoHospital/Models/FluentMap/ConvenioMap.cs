using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoHospital.Models.FluentMap
{
    public class ConvenioMap
    {
        public ConvenioMap(ModelBuilder builder)
        {
            builder.Entity<Convenio>(convenio =>
            {
                convenio.ToTable("Convenios");
                convenio.HasKey(co => new { co.IdMedico, co.IdPlano });
            });

            builder.Entity<Convenio>()
                .HasOne<Medico>(co => co.Medico)
                .WithMany(m => m.Convenios).HasForeignKey(co => co.IdMedico);

            builder.Entity<Convenio>()
                .HasOne<Plano>(co => co.Plano)
                .WithMany(p => p.Convenios).HasForeignKey(co => co.IdPlano);
        }
    }
}
