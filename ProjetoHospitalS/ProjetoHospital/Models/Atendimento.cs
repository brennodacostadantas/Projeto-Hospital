using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoHospital.Models
{
    public class Atendimento
    {
        public long Id { get; set; }

        [Required]
        public DateTime HoraInicio { get; set; }
        [Required]
        public DateTime HoraFim { get; set; }

        [Required]
        public bool AtendePlano { get; set; }

        [Required]
        public bool AtendeDia { get; set; }

        [Required]
        public int DiaSemanaId { get; set; }

        [Required]
        public DiaSemana DiaSemana { get; set; }

        [Required]
        public int MedicoId { get; set; }
        public Medico Medico { get; set; }
        [Required]
        public long AtendimentoDaConsultaId { get; set; }
        public Consulta Consulta { get; set; }
    }
}
