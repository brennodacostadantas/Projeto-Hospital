using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoHospital.Models
{
    public class Plano
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public virtual IList<Paciente> Pacientes { get; set; }
        public virtual IList<Consulta> Consultas { get; set; }
        public virtual IList<ExamePlano> ExamePlanos { get; set; }
    }
}
