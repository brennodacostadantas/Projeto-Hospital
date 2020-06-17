using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoHospital.Models
{
    public class Consulta
    {
        public long Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
        public string Tipo { get; set; }
        public float Valor { get; set; }
        public string FormaPagamento { get; set; }
        public int IdPlano { get; set; }
        public Plano Plano { get; set; }
        public int IdPaciente { get; set; }
        public Paciente Paciente { get; set; }
        public int IdAtendimento { get; set; }
        public Atendimento Atendimento { get; set; }
        public virtual IList<PrescricaoMedicamento> PrescricaoMedicamentos { get; set; }
        public virtual IList<RequisicaoExame> RequisicaoExames { get; set; }
    }
}
