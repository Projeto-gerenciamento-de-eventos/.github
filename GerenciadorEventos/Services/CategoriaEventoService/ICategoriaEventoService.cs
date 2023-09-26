using Microsoft.AspNetCore.Mvc;

namespace GerenciadorEventos.Services
{
    public interface ICategoriaEventoService
    {
        Task<ServiceResponse<List<CategoriaEventoDto>>> ObterCategoriaEventos();
        Task<ServiceResponse<CategoriaEventoDto>> ObterCategoriaEvento(int id);

        Task<ServiceResponse<CategoriaEventoDto>> CriarCategoriaEvento(CategoriaEventoDto dtoCategoriaEvento);
        Task<ServiceResponse<CategoriaEventoDto>> AtualizarCategoriaEvento(CategoriaEventoDto dtoCategoriaEvento);
        Task<ServiceResponse<CategoriaEventoDto>> DeletarCategoriaEvento(int id);
    }
}
