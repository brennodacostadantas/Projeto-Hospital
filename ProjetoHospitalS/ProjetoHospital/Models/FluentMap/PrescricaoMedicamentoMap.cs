using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoHospital.Models.FluentMap
{
    public class PrescricaoMedicamentoMap
    {
        public PrescricaoMedicamentoMap(ModelBuilder builder)
        {
            builder.Entity<PrescricaoMedicamento>(prescricao =>
            {
                prescricao.ToTable("PrescricoesMedicamentos");
                prescricao.HasKey(pr => pr.Id);
                prescricao.Property(pre => pre.Id).ValueGeneratedOnAdd();
                prescricao.Property(pr => pr.Medicamento).IsRequired().HasColumnType("varchar(20)");
                prescricao.Property(pr => pr.FormaUso).IsRequired().HasColumnType("varchar(15)");
            });

            builder.Entity<PrescricaoMedicamento>()
                .HasOne<Consulta>(pr => pr.Consulta)
                .WithMany(c => c.PrescricaoMedicamentos).HasForeignKey(pr => pr.ConsultaId);
        }
    }
}
