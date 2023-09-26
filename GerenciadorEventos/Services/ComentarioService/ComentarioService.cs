
using System.Security.Cryptography.X509Certificates;

namespace GerenciadorEventos.Services
{
    public class ComentarioService : IComentarioService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public ComentarioService(
            IMapper mapper,
            DataContext context)
        {
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));

            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }

        public async Task<ServiceResponse<List<ComentarioDto>>> ObterComentarios()
        {
            var serviceResponse = new ServiceResponse<List<ComentarioDto>>();
            var dbComentarios = await _context.ComentarioModel.ToListAsync();
            serviceResponse.Data = dbComentarios.Select(c => _mapper.Map<ComentarioDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<ComentarioDto>> ObterComentario(int id)
        {
            var serviceResponse = new ServiceResponse<ComentarioDto>();
            var dbComentario = await _context.ComentarioModel.FirstOrDefaultAsync(x => x.ID == id);
            serviceResponse.Data = _mapper.Map<ComentarioDto>(dbComentario);
            return serviceResponse;
        }

        public async Task<ServiceResponse<ComentarioDto>> CriarComentario(ComentarioDto dtoComentario)
        {
            var serviceResponse = new ServiceResponse<ComentarioDto>();

            try
            {
                var modelComentario = _mapper.Map<ComentarioModel>(dtoComentario);

                _context.ComentarioModel.Add(modelComentario);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<ComentarioDto>(modelComentario);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Erro ao criar o usuário: " + ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<ComentarioDto>> AtualizarComentario(ComentarioDto dtoComentario)
        {
            var serviceResponse = new ServiceResponse<ComentarioDto>();

            try
            {
                var dbComentario = await _context.ComentarioModel.FirstOrDefaultAsync(x => x.ID == dtoComentario.ID);
                if (dbComentario == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Usuário não encontrado.";
                    return serviceResponse;
                }

                _mapper.Map(dtoComentario, dbComentario);

                _context.ComentarioModel.Update(dbComentario);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<ComentarioDto>(dbComentario);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Erro ao atualizar o usuário: " + ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<ComentarioDto>> DeletarComentario(int id)
        {
            var serviceResponse = new ServiceResponse<ComentarioDto>();

            try
            {
                var tipoUsurio = await _context.ComentarioModel.FirstOrDefaultAsync(x => x.ID == id);
                if (tipoUsurio == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Usuário não encontrado.";
                    return serviceResponse;
                }
                _context.ComentarioModel.Remove(tipoUsurio);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<ComentarioDto>(tipoUsurio);
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
