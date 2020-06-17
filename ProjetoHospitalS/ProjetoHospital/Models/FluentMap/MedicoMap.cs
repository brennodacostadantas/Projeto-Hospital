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
                medico.Property(me => me.Id).ValueGeneratedOnAdd();
                medico.Property(m => m.Nome).IsRequired().HasColumnType("varchar(100)");
                medico.Property(m => m.CRM).IsRequired();
                medico.Property(m => m.Telefone).IsRequired().HasColumnType("varchar(15)");
                medico.Property(m => m.Atendimentos).HasDefaultValue(0);
            });

            builder.Entity<Medico>()
                .HasOne<Especialidade>(m => m.Especialidade)
                .WithMany(e => e.Medicos)
                .HasForeignKey(m => m.IdEspecialidade);

            builder.Entity<Medico>()
                .HasOne<Endereco>(m => m.Endereco)
                .WithOne(en => en.Medico)
                .HasForeignKey<Medico>(m => m.IdEndereco);
        }
    }
}
