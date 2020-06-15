using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoHospital.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string CPF { get; set; }
        public string Sexo { get; set; }
        public DateTime Nascimento { get; set; }
        public int IdPlano { get; set; }
    }
}
