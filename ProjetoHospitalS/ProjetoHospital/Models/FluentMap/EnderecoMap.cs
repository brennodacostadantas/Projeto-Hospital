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
                endereco.Property(end => end.Id).ValueGeneratedOnAdd();
                endereco.Property(en => en.Cidade).IsRequired();
                endereco.Property(en => en.Logradouro).IsRequired();
                endereco.Property(en => en.CEP).IsRequired().HasColumnType("varchar(9)");
            });

            builder.Entity<Endereco>()
                .HasOne<Estado>(en => en.Estado).WithMany(es => es.Enderecos)
                .HasForeignKey(en => en.IdEstado);
        }
    }
}
