using Microsoft.EntityFrameworkCore;
using Transportadora_Antonio_Backend.Configuration;
using Transportadora_Antonio_Backend.Enities;

namespace Transportadora_Antonio_Backend.Data
{
    /// <summary>
    /// Representa o contexto do banco de dados para a aplicação Transportadora Antonio.
    /// </summary>
    public class TransportadoraAntonioContext : DbContext
    {
        /// <summary>
        /// Inicializa uma nova instância do contexto AkkadianAcademy.
        /// </summary>
        /// <param name="options">As opções de configuração do contexto.</param>
        public TransportadoraAntonioContext(DbContextOptions<TransportadoraAntonioContext> options) : base(options)
        {
        }

        /// <summary>
        /// Configuração do modelo de entidades durante a criação do contexto.
        /// </summary>
        /// <param name="modelBuilder">O construtor do modelo.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aplica as configurações para as entidades.

            modelBuilder.ApplyConfiguration(new VeiculoConfiguration());
            modelBuilder.ApplyConfiguration(new FuncionarioConfiguration());
            modelBuilder.ApplyConfiguration(new RelacaoFuncionarioVeiculoConfiguration());
            modelBuilder.ApplyConfiguration(new EventoVeiculoConfiguration());
            modelBuilder.ApplyConfiguration(new CategoriaConfiguration());
        }

        // Conjuntos de entidades DbSet

        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<RelacaoFuncionárioVeiculo> RaEventosFuncionarios { get; set; }
        public DbSet<EventoVeiculo> EventoVeiculos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}
