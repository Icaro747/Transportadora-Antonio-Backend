namespace Transportadora_Antonio_Backend.DTOs.Veiculo
{
    public class AtulizarVeiculoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Placa { get; set; }
        public List<Guid> Funcionarios { get; set; }
    }
}
