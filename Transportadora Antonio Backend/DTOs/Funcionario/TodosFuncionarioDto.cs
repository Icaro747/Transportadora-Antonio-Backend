namespace Transportadora_Antonio_Backend.DTOs.Funcionario
{
    public class TodosFuncionarioDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string? Apelido { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? ModificadoEm { get; set; }
    }
}
