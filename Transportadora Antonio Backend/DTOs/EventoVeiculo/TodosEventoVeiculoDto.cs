namespace Transportadora_Antonio_Backend.DTOs.EventoVeiculo
{
    public class TodosEventoVeiculoDto
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public string? Descricao { get; set; }
        public decimal Valor { get; set; }
        public bool IsDespesa { get; set; }
        public Guid VeiculoId { get; set; }
        public string VeiculoPlaca { get; set; }
        public Guid CategoriaId { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? ModificadoEm { get; set; }
    }
}
