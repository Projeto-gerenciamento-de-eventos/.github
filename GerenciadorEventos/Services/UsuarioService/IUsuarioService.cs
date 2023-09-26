using Microsoft.AspNetCore.Mvc;

namespace GerenciadorEventos.Services
{
    public interface IUsuarioService
    {
        Task<ServiceResponse<List<UsuarioDto>>> ObterUsuarios();
        Task<ServiceResponse<UsuarioDto>> ObterUsuario(int id);

        Task<ServiceResponse<UsuarioDto>> CriarUsuario(UsuarioDto dtoUsuario);
        Task<ServiceResponse<UsuarioDto>> AtualizarUsuario(UsuarioDto dtoUsuario);
        Task<ServiceResponse<UsuarioDto>> DeletarUsuario(int id);
    }
}
