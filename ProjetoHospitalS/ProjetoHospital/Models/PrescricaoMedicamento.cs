using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoHospital.Models
{
    public class PrescricaoMedicamento
    {
        public long Id { get; set; }

        [Required]
        public string Medicamento { get; set; }

        [Required]
        public string FormaUso { get; set; }

        public long ConsultaId { get; set; }
        [Required]
        public Consulta Consulta { get; set; }
    }
}
