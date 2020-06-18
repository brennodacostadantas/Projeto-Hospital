using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoHospital.Models
{
    public class ExamePlano
    {
        
        public int IdExame { get; set; }
        public Exame Exame { get; set; }
        
        public int IdPlano { get; set; }
        public Plano Plano { get; set; }
    }
}
