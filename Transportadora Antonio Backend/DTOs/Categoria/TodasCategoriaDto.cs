namespace Transportadora_Antonio_Backend.DTOs.Categoria
{
    public class TodasCategoriaDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? ModificadoEm { get; set; }
    }
}
