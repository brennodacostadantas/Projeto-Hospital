using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoHospital.Models
{
    public class RequisicaoExame
    {
        public long Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataRequisicao { get; set; }
        public int Situacao { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataAgendamento { get; set; }
        public int IdExame { get; set; }
        public Exame Exame { get; set; }
        public int IdConsulta { get; set; }
        public Consulta Consulta { get; set; }
    }
}
