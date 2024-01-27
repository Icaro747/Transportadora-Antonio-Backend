using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Transportadora_Antonio_Backend.Data;
using Transportadora_Antonio_Backend.DTOs.Funcionario;
using Transportadora_Antonio_Backend.Enities;

namespace Transportadora_Antonio_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionarioController : ControllerBase
    {
        private readonly TransportadoraAntonioContext _context;
        private readonly IMapper _mapper;

        public FuncionarioController(TransportadoraAntonioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult CriarFuncionario([FromBody] CriarFuncionarioDto funcionario)
        {
            try
            {
                Funcionario NovoFuncionario = _mapper.Map<Funcionario>(funcionario);

                _context.Funcionarios.Add(NovoFuncionario);
                _context.SaveChanges();

                return Ok("funcionário criado");
            }
            catch (Exception ex)
            {
                return BadRequest($@"Erro ao criar novo funcionário: {ex.Message}");
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult AtulizarFuncionario([FromBody] AtulizarFuncionarioDto atulizarFuncionario)
        {
            try
            {
                var esteFuncionario = _context.Funcionarios.Find(atulizarFuncionario.Id);

                if(esteFuncionario == null) return NotFound("Funcionario não encontrado");

                _mapper.Map(atulizarFuncionario, esteFuncionario);
                esteFuncionario.AddUpdateDate();

                _context.Funcionarios.Update(esteFuncionario);
                _context.SaveChanges();
                
                return Ok("Funcionário atulizado");
            }
            catch (Exception ex)
            {
                return BadRequest($@"Erro ao atulizar funcionário: {ex.Message}");
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<TodosFuncionarioDto>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult TodosFuncionario()
        {
            try
            {
               var lista = _context.Funcionarios
                    .ProjectTo<TodosFuncionarioDto>(_mapper.ConfigurationProvider)
                    .ToList();

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest($@"Erro ao buscar funcionário: {ex.Message}");
            }
        }
    }
}
