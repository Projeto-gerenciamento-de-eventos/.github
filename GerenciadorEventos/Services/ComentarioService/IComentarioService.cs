using Microsoft.AspNetCore.Mvc;

namespace GerenciadorEventos.Services
{
    public interface IComentarioService
    {
        Task<ServiceResponse<List<ComentarioDto>>> ObterComentarios();
        Task<ServiceResponse<ComentarioDto>> ObterComentario(int id);

        Task<ServiceResponse<ComentarioDto>> CriarComentario(ComentarioDto dtoComentario);
        Task<ServiceResponse<ComentarioDto>> AtualizarComentario(ComentarioDto dtoComentario);
        Task<ServiceResponse<ComentarioDto>> DeletarComentario(int id);
    }
}
