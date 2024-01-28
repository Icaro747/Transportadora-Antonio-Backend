using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Transportadora_Antonio_Backend.Data;
using Transportadora_Antonio_Backend.DTOs.Categoria;
using Transportadora_Antonio_Backend.Enities;

namespace Transportadora_Antonio_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly TransportadoraAntonioContext _context;
        private readonly IMapper _mapper;

        public CategoriaController(TransportadoraAntonioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult CriarCategoria([FromBody] CriarCategoriaDto criarCategoria)
        {
            try
            {
                Categoria novaCategoria = _mapper.Map<Categoria>(criarCategoria);

                _context.Categorias.Add(novaCategoria);
                _context.SaveChanges();

                return Ok("Categoria criado");
            }
            catch (Exception ex)
            {
                return BadRequest($@"Erro ao criar novo evento do veiculo: {ex.Message}");
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult AtulizarCategoria([FromBody] AtulizarCategoriaDto atulizarCategoria)
        {
            try
            {
                var estaCategoria = _context.Categorias.Find(atulizarCategoria.Id);
                if (estaCategoria == null) return NotFound("Categoria não encontrado");

                _mapper.Map(atulizarCategoria, estaCategoria);
                estaCategoria.AddUpdateDate();

                _context.Categorias.Update(estaCategoria);
                _context.SaveChanges();

                return Ok("Categoria atulizado");
            }
            catch (Exception ex)
            {
                return BadRequest($@"Erro ao atulizar categoria: {ex.Message}");
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<TodasCategoriaDto>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult TodasCategoria()
        {
            try
            {
                var lsita = _context.Categorias
                    .ProjectTo<TodasCategoriaDto>(_mapper.ConfigurationProvider)
                    .ToList();

                return Ok(lsita);
            }
            catch (Exception ex)
            {
                return BadRequest($@"Erro ao buscar categoria: {ex.Message}");
            }
        }
    }
}
