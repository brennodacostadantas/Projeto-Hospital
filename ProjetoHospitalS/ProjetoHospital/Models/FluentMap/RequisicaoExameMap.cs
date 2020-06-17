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
            builder.Entity<RequisicaoExame>(requisicaoExame =>
            {
                requisicaoExame.ToTable("RequisicaoExames");
                requisicaoExame.HasKey(r => r.Id);
                requisicaoExame.Property(re => re.Id).ValueGeneratedOnAdd();
                requisicaoExame.Property(r => r.DataRequisicao).IsRequired();
                requisicaoExame.Property(r => r.Situacao).IsRequired();
                requisicaoExame.Property(r => r.DataAgendamento);
            });

            builder.Entity<RequisicaoExame>()
                .HasOne<Exame>(r => r.Exame).WithMany(ex => ex.RequisicaoExames)
                .HasForeignKey(r => r.IdExame);

            builder.Entity<RequisicaoExame>()
                .HasOne<Consulta>(r => r.Consulta)
                .WithMany(c => c.RequisicaoExames).HasForeignKey(r => r.IdConsulta);
        }
    }
}
