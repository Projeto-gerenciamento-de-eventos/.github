using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorEventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IEventoService _EventoService;

        public EventoController(
            IEventoService EventoService)
        {
            _EventoService = EventoService ??
                throw new ArgumentNullException(nameof(EventoService));
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<EventoDto>>>> ObterEventos()
        {
            return Ok(await _EventoService.ObterEventos());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ServiceResponse<EventoDto>>> ObterEvento(int id)
        {
            return Ok(await _EventoService.ObterEvento(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<EventoDto>>> CriarEvento([FromBody] EventoDto dtoUsuaro)
        {
            return Ok(await _EventoService.CriarEvento(dtoUsuaro));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ServiceResponse<EventoDto>>> DeletarEvento(int id)
        {
            var response = await _EventoService.DeletarEvento(id);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<EventoDto>>> AtualizarEvento([FromBody] EventoDto dtoEvento)
        {
            var response = await _EventoService.AtualizarEvento(dtoEvento);
            return Ok(response);
        }
    }
}
