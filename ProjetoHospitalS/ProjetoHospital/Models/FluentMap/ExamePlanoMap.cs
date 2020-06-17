using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoHospital.Models.FluentMap
{
    public class ExamePlanoMap
    {
        public ExamePlanoMap(ModelBuilder builder)
        {
            builder.Entity<ExamePlano>(examePlano =>
            {
                examePlano.HasKey(examePlanokey => new { examePlanokey.IdExame, examePlanokey.IdPlano });
            });

            builder.Entity<ExamePlano>()
                .HasOne<Exame>(ep => ep.Exame)
                .WithMany(e => e.ExamePlanos)
                .HasForeignKey(ep => ep.IdExame);

            builder.Entity<ExamePlano>()
                .HasOne<Plano>(ep => ep.Plano)
                .WithMany(p => p.ExamePlanos)
                .HasForeignKey(ep => ep.IdPlano);
        }
    }
}
