using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoHospital.Models.FluentMap
{
    public class ConsultaMap
    {
        public ConsultaMap(ModelBuilder builder)
        {
            builder.Entity<Consulta>(consulta =>
            {
                consulta.ToTable("Consultas");
                consulta.HasKey(c => c.Id);
                consulta.Property(co => co.Id).ValueGeneratedOnAdd();
                consulta.Property(c => c.Data).IsRequired();
                consulta.Property(c => c.Tipo).IsRequired().HasColumnType("varchar(10)");
                consulta.Property(c => c.Valor).HasColumnType("decimal(5,2)");
                consulta.Property(c => c.FormaPagamento).HasColumnType("varchar(8)");
            });

            builder.Entity<Consulta>()
                .HasOne<Paciente>().WithMany(p => p.Consultas)
                .HasForeignKey(c => c.IdPaciente);

            builder.Entity<Consulta>()
                .HasOne<Atendimento>(c => c.Atendimento).WithOne(a => a.Consulta)
                .HasForeignKey<Consulta>(c => c.IdAtendimento);
        }
    }
}
