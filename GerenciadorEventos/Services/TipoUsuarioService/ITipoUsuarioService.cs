using Microsoft.AspNetCore.Mvc;

namespace GerenciadorEventos.Services
{
    public interface ITipoUsuarioService
    {
        Task<ServiceResponse<List<TipoUsuarioDto>>> ObterTipoUsuarios();
        Task<ServiceResponse<TipoUsuarioDto>> ObterTipoUsuario(int id);

        Task<ServiceResponse<TipoUsuarioDto>> CriarTipoUsuario(string nomeTipoUsuario);
        Task<ServiceResponse<TipoUsuarioDto>> AtualizarTipoUsuario(TipoUsuarioDto dtoTipoUsuario);
        Task<ServiceResponse<TipoUsuarioDto>> DeletarTipoUsuario(int id);
    }
}
