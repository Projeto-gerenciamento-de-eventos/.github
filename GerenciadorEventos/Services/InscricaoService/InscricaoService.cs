
using System.Security.Cryptography.X509Certificates;

namespace GerenciadorEventos.Services
{
    public class InscricaoService : IInscricaoService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public InscricaoService(
            IMapper mapper,
            DataContext context)
        {
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));

            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }

        public async Task<ServiceResponse<List<InscricaoDto>>> ObterInscricaos()
        {
            var serviceResponse = new ServiceResponse<List<InscricaoDto>>();
            var dbInscricaos = await _context.InscricaoModel.ToListAsync();
            serviceResponse.Data = dbInscricaos.Select(c => _mapper.Map<InscricaoDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<InscricaoDto>> ObterInscricao(int id)
        {
            var serviceResponse = new ServiceResponse<InscricaoDto>();
            var dbInscricao = await _context.InscricaoModel.FirstOrDefaultAsync(x => x.ID == id);
            serviceResponse.Data = _mapper.Map<InscricaoDto>(dbInscricao);
            return serviceResponse;
        }

        public async Task<ServiceResponse<InscricaoDto>> CriarInscricao(InscricaoDto dtoInscricao)
        {
            var serviceResponse = new ServiceResponse<InscricaoDto>();

            try
            {
                var modelInscricao = _mapper.Map<InscricaoModel>(dtoInscricao);

                _context.InscricaoModel.Add(modelInscricao);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<InscricaoDto>(modelInscricao);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Erro ao criar o usuário: " + ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<InscricaoDto>> AtualizarInscricao(InscricaoDto dtoInscricao)
        {
            var serviceResponse = new ServiceResponse<InscricaoDto>();

            try
            {
                var dbInscricao = await _context.InscricaoModel.FirstOrDefaultAsync(x => x.ID == dtoInscricao.ID);
                if (dbInscricao == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Usuário não encontrado.";
                    return serviceResponse;
                }

                _mapper.Map(dtoInscricao, dbInscricao);

                _context.InscricaoModel.Update(dbInscricao);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<InscricaoDto>(dbInscricao);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Erro ao atualizar o usuário: " + ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<InscricaoDto>> DeletarInscricao(int id)
        {
            var serviceResponse = new ServiceResponse<InscricaoDto>();

            try
            {
                var tipoUsurio = await _context.InscricaoModel.FirstOrDefaultAsync(x => x.ID == id);
                if (tipoUsurio == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Usuário não encontrado.";
                    return serviceResponse;
                }
                _context.InscricaoModel.Remove(tipoUsurio);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<InscricaoDto>(tipoUsurio);
                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Erro ao atualizar o usuário: " + ex.Message;
                return serviceResponse;
            }
        }
    }
}
