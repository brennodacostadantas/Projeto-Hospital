using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoHospital.Models
{
    public class Medico
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string CRM { get; set; }
        [Required]
        public string Telefone { get; set; }
        public int Atendimentos { get; set; }
        public int EspecialidadeId { get; set; }
        [Required]
        public Especialidade Especialidade { get; set; }

        public int EnderecoId { get; set; }
        [Required]
        public Endereco Endereco { get; set; }
        public virtual IList<Atendimento> ListaAtendimento { get; set; }
        public virtual IList<Convenio> Convenios { get; set; }
    }
}
