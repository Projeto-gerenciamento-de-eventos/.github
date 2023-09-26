using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorCategoriaEventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaEventoController : ControllerBase
    {
        private readonly ICategoriaEventoService _CategoriaEventoService;

        public CategoriaEventoController(
            ICategoriaEventoService CategoriaEventoService)
        {
            _CategoriaEventoService = CategoriaEventoService ??
                throw new ArgumentNullException(nameof(CategoriaEventoService));
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<CategoriaEventoDto>>>> ObterCategoriaEventos()
        {
            return Ok(await _CategoriaEventoService.ObterCategoriaEventos());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ServiceResponse<CategoriaEventoDto>>> ObterCategoriaEvento(int id)
        {
            return Ok(await _CategoriaEventoService.ObterCategoriaEvento(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<CategoriaEventoDto>>> CriarCategoriaEvento([FromBody] CategoriaEventoDto dtoUsuaro)
        {
            return Ok(await _CategoriaEventoService.CriarCategoriaEvento(dtoUsuaro));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ServiceResponse<CategoriaEventoDto>>> DeletarCategoriaEvento(int id)
        {
            var response = await _CategoriaEventoService.DeletarCategoriaEvento(id);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<CategoriaEventoDto>>> AtualizarCategoriaEvento([FromBody] CategoriaEventoDto dtoCategoriaEvento)
        {
            var response = await _CategoriaEventoService.AtualizarCategoriaEvento(dtoCategoriaEvento);
            return Ok(response);
        }
    }
}
