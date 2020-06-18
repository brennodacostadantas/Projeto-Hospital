using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoHospital.Models;
using ProjetoHospital.Models.FluentMap;

namespace ProjetoHospital.Data
{
    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new AtendimentoMap(modelBuilder);
            new ConsultaMap(modelBuilder);
            new ConvenioMap(modelBuilder);
            new DiaSemanaMap(modelBuilder);
            new EnderecoMap(modelBuilder);
            new EstadoMap(modelBuilder);
            new EspecialidadeMap(modelBuilder);
            new ExameMap(modelBuilder);
            new ExamePlanoMap(modelBuilder);
            new MedicoMap(modelBuilder);
            new PacienteMap(modelBuilder);
            new PlanoMap(modelBuilder);
            new PrescricaoMedicamentoMap(modelBuilder);
            new RequisicaoExameMap(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ProjetoHospital.Models.Atendimento> Atendimento { get; set; }
        public DbSet<ProjetoHospital.Models.Estado> Estado { get; set; }
        public DbSet<ProjetoHospital.Models.DiaSemana> DiaSemana { get; set; }
        public DbSet<ProjetoHospital.Models.Endereco> Endereco { get; set; }
        public DbSet<ProjetoHospital.Models.Especialidade> Especialidade { get; set; }
        public DbSet<ProjetoHospital.Models.Medico> Medico { get; set; }
        public DbSet<ProjetoHospital.Models.Consulta> Consulta { get; set; }
        public DbSet<ProjetoHospital.Models.Paciente> Paciente { get; set; }
        public DbSet<ProjetoHospital.Models.PrescricaoMedicamento> PrescricaoMedicamento { get; set; }
        public DbSet<ProjetoHospital.Models.Exame> Exame { get; set; }
        public DbSet<ProjetoHospital.Models.RequisicaoExame> RequisicaoExame { get; set; }
        public DbSet<ProjetoHospital.Models.ExamePlano> ExamePlano { get; set; }
        public DbSet<ProjetoHospital.Models.Plano> Plano { get; set; }
        public DbSet<ProjetoHospital.Models.Convenio> Convenios { get; set; }
    }
}
