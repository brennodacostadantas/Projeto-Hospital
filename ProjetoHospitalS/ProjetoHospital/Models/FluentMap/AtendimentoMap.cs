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
                atendimento.Property(b => b.Id).ValueGeneratedOnAdd();
                atendimento.Property(a => a.HoraInicio).IsRequired().HasColumnType("datetime");
                atendimento.Property(a => a.HoraFim).IsRequired().HasColumnType("datetime");
                atendimento.Property(a => a.AtendePlano).IsRequired().HasColumnType("bit");
                atendimento.Property(a => a.AtendeDia).IsRequired().HasColumnType("bit");

                atendimento.HasOne<DiaSemana>(a => a.DiaSemana)
                .WithMany(d => d.Atendimentos)
                .HasForeignKey(a => a.DiaSemanaId);

                atendimento.HasOne<Medico>(a => a.Medico)
                .WithMany(m => m.ListaAtendimento)
                .HasForeignKey(a => a.MedicoId);

                atendimento.HasOne<Consulta>(a => a.Consulta)
                .WithOne(c => c.Atendimento)
                .HasForeignKey<Atendimento>(a => a.AtendimentoDaConsultaId);
            });
        }
    }
}
