using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoHospital.Models.FluentMap
{
    public class MedicoMap
    {
        public MedicoMap(ModelBuilder builder)
        {
            builder.Entity<Medico>(medico =>
            {
                medico.ToTable("Medicos");
                medico.HasKey(m => m.Id);
                medico.Property(a => a.Id).ValueGeneratedOnAdd();
                medico.Property(m => m.Nome).IsRequired().HasColumnType("varchar(50)");
                medico.Property(m => m.CRM).IsRequired().HasColumnType("varchar(13)");
                medico.Property(m => m.Telefone).HasColumnType("varchar(16)");
                medico.Property(m => m.Atendimentos).HasColumnName("Total_atend");
            });
            
            builder.Entity<Medico>().HasOne<Especialidade>(m => m.Especialidade)
                .WithMany(e => e.Medicos)
                .HasForeignKey(m => m.EspecialidadeId);

            builder.Entity<Medico>().HasOne<Endereco>(m => m.Endereco)
               .WithOne(en => en.Medico)
               .HasForeignKey<Medico>(m => m.EnderecoId);
        }
    }
}
