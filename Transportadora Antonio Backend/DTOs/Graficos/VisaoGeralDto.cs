namespace Transportadora_Antonio_Backend.DTOs.Graficos
{
    public class VisaoGeralDto
    {
        public decimal TotalDespesa {  get; set; }
        public decimal TotalReceita { get; set; }
        public decimal TotalLucro { get; set; }
        
        public List<VisaoGeralVeiculoDto> Veiculos {  get; set; }

        public VisaoGeralDto(decimal totalDespesa, decimal totalReceita, List<VisaoGeralVeiculoDto> veiculos) {
            TotalDespesa = totalDespesa;
            TotalReceita = totalReceita;
            TotalLucro = totalReceita - TotalDespesa;
            Veiculos = veiculos;
        }
    }

    public class VisaoGeralVeiculoDto
    {
        public Guid Id { get; set; }
        public string Placa { get; set; }
        public decimal TotalDespesa { get; set; }
        public decimal TotalReceita { get; set; }
        public decimal Totallucro { get; set; }
    }
}
