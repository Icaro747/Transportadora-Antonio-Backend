﻿namespace Transportadora_Antonio_Backend.DTOs.EventoVeiculo
{
    public class CriarEventoVeiculoDto
    {
        public DateTime Data { get; set; }
        public string? Descricao { get; set; }
        public decimal Valor { get; set; }
        public bool IsDespesa { get; set; }

        public Guid VeiculoId { get; set; }
        public Guid CategoriaId { get; set; }
    }
}
