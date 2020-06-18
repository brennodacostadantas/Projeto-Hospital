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
        [Required]
        public DateTime DataRequisicao { get; set; }

        [Required]
        public int Situacao { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime DataAgendamento { get; set; }

        public int ExameId { get; set; }
        [Required]
        public Exame Exame { get; set; }
        public long ConsultaId { get; set; }
        [Required]
        public Consulta Consulta { get; set; }
    }
}
