using Microsoft.EntityFrameworkCore.Internal;
using ProjetoHospital.Models;
using ProjetoHospital.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoHospital.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ModelContext context)
        {
            context.Database.EnsureCreated();

            if (context.Estados.Any())
            {
                return;
            }

            var estados = new Estado[]
            {
                new Estado{Id=1, Sigla="AC", Nome="Acre" },
                new Estado{Id=2, Sigla="AL", Nome="Alagoas" },
                new Estado{Id=3, Sigla="AP", Nome="Amapá" },
                new Estado{Id=4, Sigla="AM",Nome="Amazonas" },
                new Estado{Id=5,Sigla="BA",Nome="Bahia"},
                new Estado{Id=6,Sigla="CE",Nome="Ceará"},
                new Estado{Id=7,Sigla="DF",Nome="Distrito Federal"},
                new Estado{Id=8,Sigla="ES",Nome="Espírito Santo"},
                new Estado{Id=9,Sigla="GO",Nome="Goiás"},
                new Estado{Id=10,Sigla="MA",Nome="Maranhão"},
                new Estado{Id=11,Sigla="MT",Nome="Mato Grosso"},
                new Estado{Id=12,Sigla="MS",Nome="Mato Grosso do Sul"},
                new Estado{Id=13,Sigla="MG",Nome="Minas Gerais"},
                new Estado{Id=14,Sigla="PA",Nome="Pará"},
                new Estado{Id=15,Sigla="PB",Nome="Paraíba"},
                new Estado{Id=16,Sigla="PR",Nome="Paraná"},
                new Estado{Id=17,Sigla="PE",Nome="Pernambuco"},
                new Estado{Id=18,Sigla="PI",Nome="Piauí"},
                new Estado{Id=19,Sigla="RJ",Nome="Rio de Janeiro"},
                new Estado{Id=20,Sigla="RN",Nome="Rio Grande do Norte"},
                new Estado{Id=21,Sigla="RS",Nome="Rio Grande do Sul"},
                new Estado{Id=22,Sigla="RO",Nome="Rondônia"},
                new Estado{Id=23,Sigla="RR",Nome="Roraima"},
                new Estado{Id=24,Sigla="SC",Nome="Santa Catarina"},
                new Estado{Id=25,Sigla="SP",Nome="São Paulo"},
                new Estado{Id=26,Sigla="SE",Nome="Sergipe"},
                new Estado{Id=27,Sigla="TO",Nome="Tocantins"}
            };

            foreach(Estado e in estados)
            {
                context.Estados.Add(e);
            }

            context.SaveChanges();

            if (context.DiaSemanas.Any())
            {
                return;
            }

            var diasSemanas = new DiaSemana[]
            {
                new DiaSemana{Id=1, Nome="Domingo"},
                new DiaSemana{Id=2, Nome="Segunda-feira"},
                new DiaSemana{Id=3, Nome="Terça-feira"},
                new DiaSemana{Id=4, Nome="Quarta-feira"},
                new DiaSemana{Id=5, Nome="Quinta-feira"},
                new DiaSemana{Id=6, Nome="Sexta-feira"},
                new DiaSemana{Id=7, Nome="Sábado"}
            };

            foreach(DiaSemana d in diasSemanas)
            {
                context.DiaSemanas.Add(d);
            }

            context.SaveChanges();
        }
    }
}
