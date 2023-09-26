using Microsoft.AspNetCore.Mvc;

namespace GerenciadorEventos.Services
{
    public interface IEventoService
    {
        Task<ServiceResponse<List<EventoDto>>> ObterEventos();
        Task<ServiceResponse<EventoDto>> ObterEvento(int id);

        Task<ServiceResponse<EventoDto>> CriarEvento(EventoDto dtoEvento);
        Task<ServiceResponse<EventoDto>> AtualizarEvento(EventoDto dtoEvento);
        Task<ServiceResponse<EventoDto>> DeletarEvento(int id);
    }
}
