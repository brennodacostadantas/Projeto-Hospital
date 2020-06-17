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
                convenio.HasKey(conveniokey => new { conveniokey.IdMedico, conveniokey.IdPlano });
            });

            builder.Entity<Convenio>()
                .HasOne<Medico>(c => c.Medico)
                .WithMany(m => m.Convenios)
                .HasForeignKey(c => c.IdMedico);

            builder.Entity<Convenio>()
                .HasOne<Plano>(c => c.Plano)
                .WithMany(p => p.Convenios)
                .HasForeignKey(c => c.IdPlano);
        }
    }
}
