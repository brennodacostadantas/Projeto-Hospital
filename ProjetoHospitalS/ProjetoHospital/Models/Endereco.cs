using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoHospital.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        public string Cidade { get; set; }
        public string Logradouro { get; set; }
        public string CEP { get; set; }
        public int IdEstado { get; set; }
        public Estado Estado { get; set; }
        public Medico Medico { get; set; }
        public Paciente Paciente { get; set; }
    }
}
