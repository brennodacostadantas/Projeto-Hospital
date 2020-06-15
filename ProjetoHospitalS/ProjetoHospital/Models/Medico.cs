using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoHospital.Models
{
    public class Medico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CRM { get; set; }
        public string Telefone { get; set; }
        public int Atendimentos { get; set; }
        public int IdEspecialidade { get; set; }
    }
}
