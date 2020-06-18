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

        [Display(Name = "Data da consulta")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime Data { get; set; }

        [Required]
        public string Tipo { get; set; }
        public float Valor { get; set; }

        [Display(Name ="Forma de pagamento")]
        public string FormaPagamento { get; set; }
        public int PlanoId { get; set; }
        public Plano Plano { get; set; }
        public Atendimento Atendimento { get; set; }

        public int PacienteId { get; set; }
        [Required]
        public Paciente Paciente { get; set; }
        public virtual IList<PrescricaoMedicamento> PrescricaoMedicamentos { get; set; }
        public virtual IList<RequisicaoExame> RequisicaoExames { get; set; }
    }
}
