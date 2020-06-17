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
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }

        [DataType(DataType.Date)]
        public DateTime Nascimento { get; set; }
        public int IdEndereco { get; set; }
        public Endereco Endereco { get; set; }
        public int IdPlano { get; set; }
        public Plano Plano { get; set; }
        public virtual IList<Consulta> Consultas { get; set; }
    }
}
