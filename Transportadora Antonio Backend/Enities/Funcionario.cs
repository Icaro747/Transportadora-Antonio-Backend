using Transportadora_Antonio_Backend.Enities.MainClass;

namespace Transportadora_Antonio_Backend.Enities
{
    public class Funcionario : Entity
    {
        public string Nome { get; set; }
        public string? Apelido {  get; set; }

        public ICollection<RelacaoFuncionárioVeiculo> RelacaoFuncionárioVeiculo { get; set; }
    }
}
