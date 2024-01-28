using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Transportadora_Antonio_Backend.Data;
using Transportadora_Antonio_Backend.DTOs.Graficos;

namespace Transportadora_Antonio_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GraficosController : ControllerBase
    {
        private readonly TransportadoraAntonioContext _context;
        private readonly IMapper _mapper;

        public GraficosController(TransportadoraAntonioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("VisaoGeral")]
        [ProducesResponseType(typeof(VisaoGeralVeiculoDto), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult VisaoGeral([FromQuery] string mesAno)
        {
            try
            {
                if (!DateTime.TryParseExact(mesAno, "MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataPesquisa))
                {
                    return BadRequest("Formato inválido para o parâmetro mesAno. Use o formato MM/yyyy.");
                }

                var primeiroDiaMes = new DateTime(dataPesquisa.Year, dataPesquisa.Month, 1);
                var ultimoDiaMes = primeiroDiaMes.AddMonths(1).AddDays(-1);

                var totalDespesa = _context.EventoVeiculos
                    .Where(x => x.IsDespesa && x.Data >= primeiroDiaMes && x.Data <= ultimoDiaMes)
                    .Select(x => x.Valor)
                    .Sum();

                var totalReceita = _context.EventoVeiculos
                    .Where(x => !x.IsDespesa && x.Data >= primeiroDiaMes && x.Data <= ultimoDiaMes)
                    .Select(x => x.Valor)
                    .Sum();

                var resultadoPorVeiculo = _context.EventoVeiculos
                    .Where(x => x.Data >= primeiroDiaMes && x.Data <= ultimoDiaMes)
                    .GroupBy(x => x.VeiculoId)
                    .Select(group => new VisaoGeralVeiculoDto
                    {
                        Id = group.Key,
                        Placa = group.First().Veiculo.Placa,
                        TotalDespesa = group.Where(x => x.IsDespesa).Sum(x => x.Valor),
                        TotalReceita = group.Where(x => !x.IsDespesa).Sum(x => x.Valor),
                        Totallucro = group.Where(x => !x.IsDespesa).Sum(x => x.Valor) - group.Where(x => x.IsDespesa).Sum(x => x.Valor)
                    })
                    .ToList();

                VisaoGeralDto visaoGeralDto = new (totalDespesa, totalReceita, resultadoPorVeiculo);

                return Ok(visaoGeralDto);
            }
            catch (Exception ex)
            {
                return BadRequest($@"Erro ao caregar so dados de VisaoGeral: {ex.Message}");
            }
        }
    }
}
