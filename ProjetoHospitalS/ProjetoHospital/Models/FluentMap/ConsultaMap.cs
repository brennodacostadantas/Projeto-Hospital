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
                consulta.Property(con => con.Id).ValueGeneratedOnAdd();
                consulta.Property(c => c.Data).IsRequired();
                consulta.Property(c => c.Tipo).IsRequired();
                consulta.Property(c => c.Valor).HasColumnType("decimal(5,2)");
                consulta.Property(c => c.FormaPagamento).HasColumnType("varchar(8)");
            });

            builder.Entity<Consulta>()
                .HasOne<Paciente>(c => c.Paciente)
                .WithMany(p => p.Consultas).HasForeignKey(c => c.PacienteId);

            builder.Entity<Consulta>()
                .HasOne<Plano>(c => c.Plano)
                .WithMany(p => p.Consultas).HasForeignKey(c => c.PlanoId);
        }
    }
}
