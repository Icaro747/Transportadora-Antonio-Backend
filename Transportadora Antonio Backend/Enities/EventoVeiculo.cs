using Transportadora_Antonio_Backend.Enities.MainClass;

namespace Transportadora_Antonio_Backend.Enities
{
    public class EventoVeiculo : Entity
    {
        public DateTime? Data { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public bool IsDespesa { get; set; }

        public Guid VeiculoId { get; set; }
        public virtual Veiculo Veiculo { get; set; }
    }
}
