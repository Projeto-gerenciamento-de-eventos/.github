using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorInscricaos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscricaoController : ControllerBase
    {
        private readonly IInscricaoService _InscricaoService;

        public InscricaoController(
            IInscricaoService InscricaoService)
        {
            _InscricaoService = InscricaoService ??
                throw new ArgumentNullException(nameof(InscricaoService));
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<InscricaoDto>>>> ObterInscricaos()
        {
            return Ok(await _InscricaoService.ObterInscricaos());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ServiceResponse<InscricaoDto>>> ObterInscricao(int id)
        {
            return Ok(await _InscricaoService.ObterInscricao(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<InscricaoDto>>> CriarInscricao([FromBody] InscricaoDto dtoInscricao)
        {
            return Ok(await _InscricaoService.CriarInscricao(dtoInscricao));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ServiceResponse<InscricaoDto>>> DeletarInscricao(int id)
        {
            var response = await _InscricaoService.DeletarInscricao(id);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<InscricaoDto>>> AtualizarInscricao([FromBody] InscricaoDto dtoInscricao)
        {
            var response = await _InscricaoService.AtualizarInscricao(dtoInscricao);
            return Ok(response);
        }
    }
}
