using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorComentarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly IComentarioService _ComentarioService;

        public ComentarioController(
            IComentarioService ComentarioService)
        {
            _ComentarioService = ComentarioService ??
                throw new ArgumentNullException(nameof(ComentarioService));
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ComentarioDto>>>> ObterComentarios()
        {
            return Ok(await _ComentarioService.ObterComentarios());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ServiceResponse<ComentarioDto>>> ObterComentario(int id)
        {
            return Ok(await _ComentarioService.ObterComentario(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<ComentarioDto>>> CriarComentario([FromBody] ComentarioDto dtoUsuaro)
        {
            return Ok(await _ComentarioService.CriarComentario(dtoUsuaro));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ServiceResponse<ComentarioDto>>> DeletarComentario(int id)
        {
            var response = await _ComentarioService.DeletarComentario(id);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<ComentarioDto>>> AtualizarComentario([FromBody] ComentarioDto dtoComentario)
        {
            var response = await _ComentarioService.AtualizarComentario(dtoComentario);
            return Ok(response);
        }
    }
}
