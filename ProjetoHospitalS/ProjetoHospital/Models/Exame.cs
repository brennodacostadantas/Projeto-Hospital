using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoHospital.Models
{
    public class Exame
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public float Valor { get; set; }
        public virtual IList<ExamePlano> ExamePlanos { get; set; }
        public virtual IList<RequisicaoExame> RequisicaoExames { get; set; }

    }
}
