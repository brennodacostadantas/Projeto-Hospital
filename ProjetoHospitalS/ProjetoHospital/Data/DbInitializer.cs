using ProjetoHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoHospital.Data
{
    public class DbInitializer
    {
        public static void Initialize(Context context)
        {
            context.Database.EnsureCreated();

            if (context.DiaSemana.Any())
            {
                return;
            }
            var diasSemanas = new DiaSemana[]
            {
                new DiaSemana{Id=1, Nome="Domingo" },
                new DiaSemana{Id=2, Nome="Segunda-feira"},
                new DiaSemana{Id=3, Nome="Terça-feira"},
                new DiaSemana{Id=4, Nome="Quarta-feira"},
                new DiaSemana{Id=5, Nome="Quinta-feira"},
                new DiaSemana{Id=6, Nome="Sexta-feira"},
                new DiaSemana{Id=7, Nome="Sábado"}
            };
            foreach(DiaSemana d in diasSemanas)
            {
                context.DiaSemana.Add(d);
            }
            context.SaveChanges();
        }
    }
}
