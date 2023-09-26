using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorUsuarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _UsuarioService;

        public UsuarioController(
            IUsuarioService UsuarioService)
        {
            _UsuarioService = UsuarioService ??
                throw new ArgumentNullException(nameof(UsuarioService));
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<UsuarioDto>>>> ObterUsuarios()
        {
            return Ok(await _UsuarioService.ObterUsuarios());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ServiceResponse<UsuarioDto>>> ObterUsuario(int id)
        {
            return Ok(await _UsuarioService.ObterUsuario(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<UsuarioDto>>> CriarUsuario([FromBody] UsuarioDto dtoUsuaro)
        {
            return Ok(await _UsuarioService.CriarUsuario(dtoUsuaro));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ServiceResponse<UsuarioDto>>> DeletarUsuario(int id)
        {
            var response = await _UsuarioService.DeletarUsuario(id);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<UsuarioDto>>> AtualizarUsuario([FromBody] UsuarioDto dtoUsuario)
        {
            var response = await _UsuarioService.AtualizarUsuario(dtoUsuario);
            return Ok(response);
        }
    }
}
