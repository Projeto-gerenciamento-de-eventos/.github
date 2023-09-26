
using System.Security.Cryptography.X509Certificates;

namespace GerenciadorEventos.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public UsuarioService(
            IMapper mapper,
            DataContext context)
        {
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));

            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }

        public async Task<ServiceResponse<List<UsuarioDto>>> ObterUsuarios()
        {
            var serviceResponse = new ServiceResponse<List<UsuarioDto>>();
            var dbUsuarios = await _context.UsuarioModel.ToListAsync();
            serviceResponse.Data = dbUsuarios.Select(c => _mapper.Map<UsuarioDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<UsuarioDto>> ObterUsuario(int id)
        {
            var serviceResponse = new ServiceResponse<UsuarioDto>();
            var dbUsuario = await _context.UsuarioModel.FirstOrDefaultAsync(x => x.ID == id);
            serviceResponse.Data = _mapper.Map<UsuarioDto>(dbUsuario);
            return serviceResponse;
        }

        public async Task<ServiceResponse<UsuarioDto>> CriarUsuario(UsuarioDto dtoUsuario)
        {
            var serviceResponse = new ServiceResponse<UsuarioDto>();

            try
            {
                var modelUsuario = _mapper.Map<UsuarioModel>(dtoUsuario);

                _context.UsuarioModel.Add(modelUsuario);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<UsuarioDto>(modelUsuario);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Erro ao criar o usuário: " + ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<UsuarioDto>> AtualizarUsuario(UsuarioDto dtoUsuario)
        {
            var serviceResponse = new ServiceResponse<UsuarioDto>();

            try
            {
                var dbUsuario = await _context.UsuarioModel.FirstOrDefaultAsync(x => x.ID == dtoUsuario.ID);
                if (dbUsuario == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Usuário não encontrado.";
                    return serviceResponse;
                }

                _mapper.Map(dtoUsuario, dbUsuario);

                _context.UsuarioModel.Update(dbUsuario);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<UsuarioDto>(dbUsuario);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Erro ao atualizar o usuário: " + ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<UsuarioDto>> DeletarUsuario(int id)
        {
            var serviceResponse = new ServiceResponse<UsuarioDto>();

            try
            {
                var tipoUsurio = await _context.UsuarioModel.FirstOrDefaultAsync(x => x.ID == id);
                if (tipoUsurio == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Usuário não encontrado.";
                    return serviceResponse;
                }
                _context.UsuarioModel.Remove(tipoUsurio);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<UsuarioDto>(tipoUsurio);
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
