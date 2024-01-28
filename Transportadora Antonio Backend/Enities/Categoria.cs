using Transportadora_Antonio_Backend.Enities.MainClass;

namespace Transportadora_Antonio_Backend.Enities
{
    public class Categoria : Entity
    {
        public string Nome { get; set; }

        public ICollection<EventoVeiculo> EventoVeiculos { get; set; }
    }
}
