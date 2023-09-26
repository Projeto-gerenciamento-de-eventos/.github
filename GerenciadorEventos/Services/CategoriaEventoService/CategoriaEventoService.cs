
using System.Security.Cryptography.X509Certificates;

namespace GerenciadorEventos.Services
{
    public class CategoriaEventoService : ICategoriaEventoService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CategoriaEventoService(
            IMapper mapper,
            DataContext context)
        {
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));

            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }

        public async Task<ServiceResponse<List<CategoriaEventoDto>>> ObterCategoriaEventos()
        {
            var serviceResponse = new ServiceResponse<List<CategoriaEventoDto>>();
            var dbCategoriaEventos = await _context.CategoriaEventoModel.ToListAsync();
            serviceResponse.Data = dbCategoriaEventos.Select(c => _mapper.Map<CategoriaEventoDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<CategoriaEventoDto>> ObterCategoriaEvento(int id)
        {
            var serviceResponse = new ServiceResponse<CategoriaEventoDto>();
            var dbCategoriaEvento = await _context.CategoriaEventoModel.FirstOrDefaultAsync(x => x.ID == id);
            serviceResponse.Data = _mapper.Map<CategoriaEventoDto>(dbCategoriaEvento);
            return serviceResponse;
        }

        public async Task<ServiceResponse<CategoriaEventoDto>> CriarCategoriaEvento(CategoriaEventoDto dtoCategoriaEvento)
        {
            var serviceResponse = new ServiceResponse<CategoriaEventoDto>();

            try
            {
                var modelCategoriaEvento = _mapper.Map<CategoriaEventoModel>(dtoCategoriaEvento);

                _context.CategoriaEventoModel.Add(modelCategoriaEvento);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<CategoriaEventoDto>(modelCategoriaEvento);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Erro ao criar o usuário: " + ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<CategoriaEventoDto>> AtualizarCategoriaEvento(CategoriaEventoDto dtoCategoriaEvento)
        {
            var serviceResponse = new ServiceResponse<CategoriaEventoDto>();

            try
            {
                var dbCategoriaEvento = await _context.CategoriaEventoModel.FirstOrDefaultAsync(x => x.ID == dtoCategoriaEvento.ID);
                if (dbCategoriaEvento == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Usuário não encontrado.";
                    return serviceResponse;
                }

                _mapper.Map(dtoCategoriaEvento, dbCategoriaEvento);

                _context.CategoriaEventoModel.Update(dbCategoriaEvento);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<CategoriaEventoDto>(dbCategoriaEvento);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Erro ao atualizar o usuário: " + ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<CategoriaEventoDto>> DeletarCategoriaEvento(int id)
        {
            var serviceResponse = new ServiceResponse<CategoriaEventoDto>();

            try
            {
                var tipoUsurio = await _context.CategoriaEventoModel.FirstOrDefaultAsync(x => x.ID == id);
                if (tipoUsurio == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Usuário não encontrado.";
                    return serviceResponse;
                }
                _context.CategoriaEventoModel.Remove(tipoUsurio);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<CategoriaEventoDto>(tipoUsurio);
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
