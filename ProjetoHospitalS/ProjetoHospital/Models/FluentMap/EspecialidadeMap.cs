﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoHospital.Models.FluentMap
{
    public class EspecialidadeMap
    {
        public EspecialidadeMap(ModelBuilder builder)
        {
            builder.Entity<Especialidade>(especialidade =>
            {
                especialidade.ToTable("Especialidades");
                especialidade.HasKey(e => e.Id);
                especialidade.Property(a => a.Id).ValueGeneratedOnAdd();
                especialidade.Property(e => e.Descricao).IsRequired().HasColumnType("varchar(150)");
            });
        }
    }
}
