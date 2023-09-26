
using System.Security.Cryptography.X509Certificates;

namespace GerenciadorEventos.Services
{
    public class TipoUsuarioService : ITipoUsuarioService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;


        public TipoUsuarioService(
            IMapper mapper,
            DataContext context)
        {
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));

            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }

        public async Task<ServiceResponse<List<TipoUsuarioDto>>> ObterTipoUsuarios()
        {
            var serviceResponse = new ServiceResponse<List<TipoUsuarioDto>>();
            var dbTipoUsuarios = await _context.TipoUsuarioModel.ToListAsync();
            serviceResponse.Data = dbTipoUsuarios.Select(c => _mapper.Map<TipoUsuarioDto>(c)).ToList();
            return serviceResponse;
        }


        public async Task<ServiceResponse<TipoUsuarioDto>> ObterTipoUsuario(int id)
        {
            var serviceResponse = new ServiceResponse<TipoUsuarioDto>();
            var dbTipoUsuario = await _context.TipoUsuarioModel.FirstOrDefaultAsync(x => x.ID == id);
            serviceResponse.Data = _mapper.Map<TipoUsuarioDto>(dbTipoUsuario);
            return serviceResponse;
        }

        public async Task<ServiceResponse<TipoUsuarioDto>> CriarTipoUsuario(string nomeTipoUsuario)
        {
            var serviceResponse = new ServiceResponse<TipoUsuarioDto>();
            var tipoUsuario = new TipoUsuarioModel()
            {
                Nome = nomeTipoUsuario
            };

            try
            {
                _context.TipoUsuarioModel.Add(tipoUsuario);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<TipoUsuarioDto>(tipoUsuario);
                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Erro ao criar o usuário: " + ex.Message;
                return serviceResponse;
            }
        }


        public async Task<ServiceResponse<TipoUsuarioDto>> AtualizarTipoUsuario(TipoUsuarioDto tipoUsuario)
        {
            var serviceResponse = new ServiceResponse<TipoUsuarioDto>();

            try
            {
                var dbTipoUsuario = await _context.TipoUsuarioModel.FirstOrDefaultAsync(x => x.ID == tipoUsuario.ID);
                if (dbTipoUsuario == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Usuário não encontrado.";
                    return serviceResponse;
                }

                _mapper.Map(tipoUsuario, dbTipoUsuario);

                _context.TipoUsuarioModel.Update(dbTipoUsuario);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<TipoUsuarioDto>(dbTipoUsuario);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Erro ao atualizar o usuário: " + ex.Message;
            }

            return serviceResponse;
        }




        public async Task<ServiceResponse<TipoUsuarioDto>> DeletarTipoUsuario(int id)
        {
            var serviceResponse = new ServiceResponse<TipoUsuarioDto>();

            try
            {
                var tipoUsurio = await _context.TipoUsuarioModel.FirstOrDefaultAsync(x => x.ID == id);
                if (tipoUsurio == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Usuário não encontrado.";
                    return serviceResponse;
                }
                _context.TipoUsuarioModel.Remove(tipoUsurio);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<TipoUsuarioDto>(tipoUsurio);
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
