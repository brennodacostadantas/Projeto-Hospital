using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoHospital.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Sexo { get; set; }

        [Display(Name ="Data de Nascimento")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime Nascimento { get; set; }
        public int EnderecoId { get; set; }
        [Required]
        public Endereco Endereco { get; set; }
        public int PlanoId { get; set; }
        [Required]
        public Plano Plano { get; set; }
        public virtual IList<Consulta> Consultas { get; set; }
    }
}
