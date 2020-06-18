using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoHospital.Models.FluentMap
{
    public class RequisicaoExameMap
    {
        public RequisicaoExameMap(ModelBuilder builder)
        {
            builder.Entity<RequisicaoExame>(reqExame =>
            {
                reqExame.ToTable("RequisicoesExames");
                reqExame.HasKey(r => r.Id);
                reqExame.Property(re => re.Id).ValueGeneratedOnAdd();
                reqExame.Property(r => r.DataAgendamento).IsRequired().HasColumnType("datetime");
                reqExame.Property(r => r.DataRequisicao).HasColumnType("datetime");
                reqExame.Property(r => r.Situacao).HasColumnName("situacao");               
            });

            builder.Entity<RequisicaoExame>().HasOne<Consulta>(r => r.Consulta)
                .WithMany(c => c.RequisicaoExames)
                .HasForeignKey(r => r.ConsultaId);

            builder.Entity<RequisicaoExame>().HasOne<Exame>(r => r.Exame)
                .WithMany(ex => ex.RequisicaoExames)
                .HasForeignKey(r => r.ExameId);
        }
    }
}
