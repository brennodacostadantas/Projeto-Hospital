using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoHospital.Models
{
    public class DiaSemana
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual IList<Atendimento> Atendimentos { get; set; }
    }
}
