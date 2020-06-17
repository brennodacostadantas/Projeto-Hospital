using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoHospital.Models
{
    public class Convenio
    {
        public int IdPlano { get; set; }
        public Plano Plano { get; set; }
        public int IdMedico { get; set; }
        public Medico Medico { get; set; }
    }
}
