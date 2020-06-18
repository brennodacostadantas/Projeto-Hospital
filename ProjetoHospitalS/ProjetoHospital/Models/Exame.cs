using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoHospital.Models
{
    public class Exame
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [Display(Name ="Descrição")]
        public string Descricao { get; set; }
        public float Custo { get; set; }
        [Display(Name ="Para pacientes do sexo")]
        public string SexoPaciente { get; set; }
        [Display(Name ="Para pacientes com idade")]
        public string IdadePaciente { get; set; }
        public float Parametro { get; set; }
        public float ValorMinimo { get; set; }
        public float ValorMaximo { get; set; }
        public virtual IList<ExamePlano> ExamePlanos { get; set; }
        public virtual IList<RequisicaoExame> RequisicaoExames { get; set; }
    }
}
