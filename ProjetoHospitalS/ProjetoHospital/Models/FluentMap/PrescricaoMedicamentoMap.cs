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
            builder.Entity<PrescricaoMedicamento>(prescricaoMedicamento =>
            {
                prescricaoMedicamento.ToTable("PrescricaoMedicamentos");
                prescricaoMedicamento.HasKey(pm => pm.Id);
                prescricaoMedicamento.Property(pem => pem.Id).ValueGeneratedOnAdd();
                prescricaoMedicamento.Property(pm => pm.Medicamento).IsRequired();
                prescricaoMedicamento.Property(pm => pm.FormaUso).IsRequired();
            });

            builder.Entity<PrescricaoMedicamento>()
                .HasOne<Consulta>(pm => pm.Consulta).WithMany(c => c.PrescricaoMedicamentos)
                .HasForeignKey(pm => pm.Consulta);
        }
    }
}
