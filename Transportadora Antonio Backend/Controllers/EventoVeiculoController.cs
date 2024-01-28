using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Transportadora_Antonio_Backend.Data;
using Transportadora_Antonio_Backend.DTOs.EventoVeiculo;
using Transportadora_Antonio_Backend.Enities;

namespace Transportadora_Antonio_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventoVeiculoController : ControllerBase
    {
        private readonly TransportadoraAntonioContext _context;
        private readonly IMapper _mapper;

        public EventoVeiculoController(TransportadoraAntonioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult CriarEventoVeiculo([FromBody] CriarEventoVeiculoDto eventoVeiculo)
        {
            try
            {
                EventoVeiculo NovoEventoVeiculo = _mapper.Map<EventoVeiculo>(eventoVeiculo);

                _context.EventoVeiculos.Add(NovoEventoVeiculo);
                _context.SaveChanges();

                return Ok("Evento do veiculo criado");
            }
            catch (Exception ex)
            {
                return BadRequest($@"Erro ao criar novo evento do veiculo: {ex.Message}");
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 404)]
        public IActionResult AtulizarEventoVeiculo([FromBody] AtulizarEventoVeiculoDto atulizarEventoVeiculo)
        {
            try
            {
                var esteEventoVeiculo = _context.EventoVeiculos.Find(atulizarEventoVeiculo.Id);

                if (esteEventoVeiculo == null) return NotFound("Evento do veiculo não encontrado");

                _mapper.Map(atulizarEventoVeiculo, esteEventoVeiculo);
                esteEventoVeiculo.AddUpdateDate();

                _context.EventoVeiculos.Update(esteEventoVeiculo);
                _context.SaveChanges();

                return Ok("Evento do veiculo atulizado");
            }
            catch (Exception ex)
            {
                return BadRequest($@"Erro ao atulizar evento do veiculo: {ex.Message}");
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<TodosEventoVeiculoDto>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult TodosEventoVeiculo()
        {
            try
            {
                var lista = _context.EventoVeiculos
                    .ProjectTo<TodosEventoVeiculoDto>(_mapper.ConfigurationProvider)
                    .ToList();

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest($@"Erro ao buscar evento veiculo: {ex.Message}");
            }
        }

        [HttpDelete]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 404)]
        public IActionResult RemoverEventoVeiculo([FromQuery] Guid id)
        {
            try
            {
                var estaEventoVeiculo = _context.EventoVeiculos.Find(id);
                if (estaEventoVeiculo == null) return NotFound("");

                _context.EventoVeiculos.Remove(estaEventoVeiculo);
                _context.SaveChanges();

                return Ok("evento veiculo remover");
            }
            catch (Exception ex)
            {
                return BadRequest($@"Erro ao remover evento veiculo: {ex.Message}");
            }
        }

    }
}
