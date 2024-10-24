using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        public DbSet<AgendamentoModel> Agendamento { get; set; }
        public DbSet<AssinaturaClubeModel> AssinaturaClube { get; set; }
        public DbSet<ClienteModel> Cliente { get; set; }
        public DbSet<ClubeModel> Clube { get; set; }
        public DbSet<FormaPagamentoModel> FormaPagamento { get; set; }
        public DbSet<PagamentoAgendamentoModel> PagamentoAgendamento { get; set; }
        public DbSet<PagamentoAssinaturaModel> PagamentoAssinatura { get; set; }
        public DbSet<ProcedimentoModel> Procedimento { get; set; }
        public DbSet<ProfissionalModel> Profissional { get; set; }
        public DbSet<TipoClubeModel> TipoClube { get; set; }
        public DbSet<TipoPlanoModel> TipoPlano { get; set; }
        public DbSet<TipoProcedimentoModel> TipoProcedimento { get; set; }
        public DbSet<TipoProfissionalModel> TipoProfissional { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AgendamentoMap());
            modelBuilder.ApplyConfiguration(new AssinaturaClubeMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new ClubeMap());
            modelBuilder.ApplyConfiguration(new FormaPagamentoMap());
            modelBuilder.ApplyConfiguration(new PagamentoAgendamentoMap());
            modelBuilder.ApplyConfiguration(new PagamentoAssinaturaMap());
            modelBuilder.ApplyConfiguration(new ProcedimentoMap());
            modelBuilder.ApplyConfiguration(new ProfissionalMap());
            modelBuilder.ApplyConfiguration(new TipoClubeMap());
            modelBuilder.ApplyConfiguration(new TipoPlanoMap());
            modelBuilder.ApplyConfiguration(new TipoProcedimentoMap());
            modelBuilder.ApplyConfiguration(new TipoProfissionalMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}
