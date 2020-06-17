using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoHospital.Models
{
    public class PrescricaoMedicamento
    {
        public long Id { get; set; }
        public string Medicamento { get; set; }
        public string FormaUso { get; set; }
        public long IdConsulta { get; set; }
        public Consulta Consulta { get; set; }
    }
}
