using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorTipoUsuarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private readonly ITipoUsuarioService _TipoUsuarioService;

        public TipoUsuarioController(
            ITipoUsuarioService TipoUsuarioService)
        {
            _TipoUsuarioService = TipoUsuarioService ??
                throw new ArgumentNullException(nameof(TipoUsuarioService));
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<TipoUsuarioDto>>>> ObterTipoUsuarios()
        {
            return Ok(await _TipoUsuarioService.ObterTipoUsuarios());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ServiceResponse<TipoUsuarioDto>>> ObterTipoUsuario(int id)
        {
            return Ok(await _TipoUsuarioService.ObterTipoUsuario(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TipoUsuarioDto>>> CriarTipoUsuario([FromBody] string nome)
        {
            return Ok(await _TipoUsuarioService.CriarTipoUsuario(nome));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ServiceResponse<TipoUsuarioDto>>> DeletarTipoUsuario(int id)
        {
            var response = await _TipoUsuarioService.DeletarTipoUsuario(id);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<TipoUsuarioDto>>> AtualizarTipoUsuario([FromBody] TipoUsuarioDto TipoUsuario)
        {
            var response = await _TipoUsuarioService.AtualizarTipoUsuario(TipoUsuario);
            return Ok(response);
        }
    }
}
