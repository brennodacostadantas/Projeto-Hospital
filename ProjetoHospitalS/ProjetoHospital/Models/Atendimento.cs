using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoHospital.Models
{
    public class Atendimento
    {
        public long Id { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFim { get; set; }
        public bool AtendePlano { get; set; }
        public bool AtendeDia { get; set; }
        public int IdDiaSemana { get; set; }
        public int IdMedico { get; set; }

    }
}
