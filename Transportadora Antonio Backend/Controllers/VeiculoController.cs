using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Transportadora_Antonio_Backend.Data;
using Transportadora_Antonio_Backend.DTOs.Veiculo;
using Transportadora_Antonio_Backend.Enities;

namespace Transportadora_Antonio_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VeiculoController : ControllerBase
    {
        private readonly TransportadoraAntonioContext _context;
        private readonly IMapper _mapper;

        public VeiculoController(TransportadoraAntonioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult CriarVeiculo([FromBody] CriarVeiculoDto criarVeiculo)
        {
            try
            {
                Veiculo NovoVeiculo = _mapper.Map<Veiculo>(criarVeiculo);

                foreach (var item in criarVeiculo.Funcionarios)
                {
                    NovoVeiculo.RelacaoFuncionárioVeiculo.Add(new RelacaoFuncionárioVeiculo { FuncionarioId = item, VeiculoId = NovoVeiculo.Id });
                }

                _context.Veiculos.Add(NovoVeiculo);
                _context.SaveChanges();

                return Ok("veiculo criado");
            }
            catch (Exception ex)
            {
                return BadRequest($@"Erro ao criar novo veiculo: {ex.Message}");
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult AtulizarVeiculo([FromBody] AtulizarVeiculoDto atulizarVeiculo)
        {
            try
            {
                var esteVeiculo = _context.Veiculos
                    .Include(v => v.RelacaoFuncionárioVeiculo)
                    .FirstOrDefault(v => v.Id == atulizarVeiculo.Id);

                if (esteVeiculo == null) return NotFound("Veiculo não encontrado");

                _mapper.Map(atulizarVeiculo, esteVeiculo);
                esteVeiculo.AddUpdateDate();

                // Atualizar relacionamentos
                UpdateRelacoesFuncionarioVeiculo(esteVeiculo, atulizarVeiculo.Funcionarios);

                _context.Veiculos.Update(esteVeiculo);
                _context.SaveChanges();

                return Ok("Veiculo atulizado");
            }
            catch (Exception ex)
            {
                return BadRequest($@"Erro ao atulizar veiculo: {ex.Message}");
            }
        }

        private void UpdateRelacoesFuncionarioVeiculo(Veiculo veiculo, List<Guid> funcionarioIds)
        {
            // Relações existentes
            var existingRelacoes = veiculo.RelacaoFuncionárioVeiculo.ToList();

            // Novas relações a serem adicionadas
            var newRelacoes = funcionarioIds
                .Except(existingRelacoes.Select(r => r.FuncionarioId))
                .Select(funcionarioId => new RelacaoFuncionárioVeiculo
                {
                    FuncionarioId = funcionarioId,
                    VeiculoId = veiculo.Id
                });

            // Remover relações que não estão na nova lista
            var relacoesToRemove = existingRelacoes
                .Where(r => !funcionarioIds.Contains(r.FuncionarioId))
                .ToList();

            // Converter para List e adicionar novas relações
            veiculo.RelacaoFuncionárioVeiculo = veiculo.RelacaoFuncionárioVeiculo.Concat(newRelacoes).ToList();

            // Remover relações antigas
            foreach (var relacao in relacoesToRemove)
            {
                veiculo.RelacaoFuncionárioVeiculo.Remove(relacao);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<TodosVeiculoDto>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult TodosVeiculos()
        {
            try
            {
                var lista = _context.Veiculos
                     .ProjectTo<TodosVeiculoDto>(_mapper.ConfigurationProvider)
                     .ToList();

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest($@"Erro ao buscar veiculo: {ex.Message}");
            }
        }
    }
}
