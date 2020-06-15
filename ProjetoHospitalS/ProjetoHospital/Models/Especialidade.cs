using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoHospital.Models
{
    public class Especialidade
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public virtual IList<Medico> Medicos { get; set; }
    }
}
