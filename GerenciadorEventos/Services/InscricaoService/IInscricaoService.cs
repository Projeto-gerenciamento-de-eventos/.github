using Microsoft.AspNetCore.Mvc;

namespace GerenciadorEventos.Services
{
    public interface IInscricaoService
    {
        Task<ServiceResponse<List<InscricaoDto>>> ObterInscricaos();
        Task<ServiceResponse<InscricaoDto>> ObterInscricao(int id);

        Task<ServiceResponse<InscricaoDto>> CriarInscricao(InscricaoDto dtoInscricao);
        Task<ServiceResponse<InscricaoDto>> AtualizarInscricao(InscricaoDto dtoInscricao);
        Task<ServiceResponse<InscricaoDto>> DeletarInscricao(int id);
    }
}
