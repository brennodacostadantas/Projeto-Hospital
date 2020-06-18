using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoHospital.Models.FluentMap
{
    public class EnderecoMap
    {
        public EnderecoMap(ModelBuilder builder)
        {
            builder.Entity<Endereco>(endereco =>
            {
                endereco.ToTable("Enderecos");
                endereco.HasKey(en => en.Id);
                endereco.Property(e => e.Id).ValueGeneratedOnAdd();
                endereco.Property(en => en.Cidade).IsRequired().HasColumnType("varchar(200)");
                endereco.Property(en => en.Logradouro).IsRequired().HasColumnType("varchar(200)");
                endereco.Property(en => en.CEP).IsRequired().HasColumnType("varchar(10)");                                            
            });

            builder.Entity<Endereco>().HasOne<Estado>(en => en.Estado)
                .WithMany(es => es.ListaEndereco)
                .HasForeignKey(en => en.EstadoId);

            builder.Entity<Endereco>().HasOne<Medico>(en => en.Medico)
                .WithOne(m => m.Endereco)
                .HasForeignKey<Medico>(m => m.EnderecoId);

            builder.Entity<Endereco>().HasOne<Paciente>(en => en.Paciente)
                .WithOne(p => p.Endereco)
                .HasForeignKey<Paciente>(p => p.EnderecoId);
        }
    }
}
