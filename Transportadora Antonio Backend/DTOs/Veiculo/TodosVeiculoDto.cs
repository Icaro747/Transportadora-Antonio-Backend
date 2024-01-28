namespace Transportadora_Antonio_Backend.DTOs.Veiculo
{
    public class TodosVeiculoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Placa { get; set; }
        public List<Guid> Funcionarios { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? ModificadoEm { get; set; }
    }
}
