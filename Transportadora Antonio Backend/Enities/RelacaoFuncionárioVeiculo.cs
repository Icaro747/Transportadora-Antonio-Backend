using Transportadora_Antonio_Backend.Enities.MainClass;

namespace Transportadora_Antonio_Backend.Enities
{
    public class RelacaoFuncionárioVeiculo : Entity
    {
        public Guid FuncionarioId { get; set; }
        public Guid VeiculoId { get; set; }

        public virtual Funcionario Funcionario { get; set; }
        public virtual Veiculo Veiculo { get; set; }
    }
}
