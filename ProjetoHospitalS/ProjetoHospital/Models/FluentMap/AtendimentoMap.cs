using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoHospital.Models.FluentMap
{
    public class AtendimentoMap
    {
        public AtendimentoMap(ModelBuilder builder)
        {
            builder.Entity<Atendimento>(atendimento =>
            {
                atendimento.ToTable("Atendimentos");
                atendimento.HasKey(a => a.Id);
                atendimento.Property(at => at.Id).ValueGeneratedOnAdd();
                atendimento.Property(a => a.HoraInicio).IsRequired();
                atendimento.Property(a => a.HoraFim).IsRequired();
                atendimento.Property(a => a.AtendePlano).IsRequired();
                atendimento.Property(a => a.AtendeDia).IsRequired();
            });

            builder.Entity<Atendimento>()
                .HasOne<DiaSemana>(a => a.DiaSemana)
                .WithMany(d => d.Atendimentos)
                .HasForeignKey(a => a.IdDiaSemana);

            builder.Entity<Atendimento>()
                .HasOne<Medico>(a => a.Medico)
                .WithMany(m => m.ListaDeAtendimentos)
                .HasForeignKey(a => a.IdMedico);
        }
    }
}
