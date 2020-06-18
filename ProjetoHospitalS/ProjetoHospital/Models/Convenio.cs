using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoHospital.Models
{
    public class Convenio
    {      
        public int IdMedico { get; set; }

        [Required]
        public Medico Medico { get; set; }
        public int IdPlano{ get; set; }

        [Required]
        public Plano Plano { get; set; }
    }
}
