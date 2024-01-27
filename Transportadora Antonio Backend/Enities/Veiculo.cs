using Transportadora_Antonio_Backend.Enities.MainClass;

namespace Transportadora_Antonio_Backend.Enities
{
    public class Veiculo : Entity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Placa { get; set; }

        public ICollection<RelacaoFuncionárioVeiculo> RelacaoFuncionárioVeiculo { get; set; }
        public ICollection<EventoVeiculo> EventosVeiculo { get; set; }
    }
}
