﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoHospital.Models.FluentMap
{
    public class PacienteMap
    {
        public PacienteMap(ModelBuilder builder)
        {
            builder.Entity<Paciente>(paciente =>
            {
                paciente.ToTable("Pacientes");
                paciente.HasKey(p => p.Id);
                paciente.Property(pa => pa.Id).ValueGeneratedOnAdd();
                paciente.Property(pa => pa.CPF).IsRequired().HasColumnType("varchar(15)");
                paciente.Property(p => p.Nome).IsRequired().HasColumnType("varchar(100)");
                paciente.Property(p => p.Sexo).IsRequired().HasColumnType("varchar(9)");
                paciente.Property(p => p.Nascimento).IsRequired();               
            });

            builder.Entity<Paciente>().HasOne<Plano>(p => p.Plano)
               .WithMany(pl => pl.Pacientes)
               .HasForeignKey(p => p.PlanoId);

            builder.Entity<Paciente>().HasOne<Endereco>(p => p.Endereco)
                .WithOne(en => en.Paciente)
                .HasForeignKey<Paciente>(p => p.EnderecoId);
        }
    }
}
