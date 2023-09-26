
using System.Security.Cryptography.X509Certificates;

namespace GerenciadorEventos.Services
{
    public class EventoService : IEventoService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public EventoService(
            IMapper mapper,
            DataContext context)
        {
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));

            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }

        public async Task<ServiceResponse<List<EventoDto>>> ObterEventos()
        {
            var serviceResponse = new ServiceResponse<List<EventoDto>>();
            var dbEventos = await _context.EventoModel.ToListAsync();
            serviceResponse.Data = dbEventos.Select(c => _mapper.Map<EventoDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<EventoDto>> ObterEvento(int id)
        {
            var serviceResponse = new ServiceResponse<EventoDto>();
            var dbEvento = await _context.EventoModel.FirstOrDefaultAsync(x => x.ID == id);
            serviceResponse.Data = _mapper.Map<EventoDto>(dbEvento);
            return serviceResponse;
        }

        public async Task<ServiceResponse<EventoDto>> CriarEvento(EventoDto dtoEvento)
        {
            var serviceResponse = new ServiceResponse<EventoDto>();

            try
            {
                var modelEvento = _mapper.Map<EventoModel>(dtoEvento);

                _context.EventoModel.Add(modelEvento);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<EventoDto>(modelEvento);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Erro ao criar o usuário: " + ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<EventoDto>> AtualizarEvento(EventoDto dtoEvento)
        {
            var serviceResponse = new ServiceResponse<EventoDto>();

            try
            {
                var dbEvento = await _context.EventoModel.FirstOrDefaultAsync(x => x.ID == dtoEvento.ID);
                if (dbEvento == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Usuário não encontrado.";
                    return serviceResponse;
                }

                _mapper.Map(dtoEvento, dbEvento);

                _context.EventoModel.Update(dbEvento);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<EventoDto>(dbEvento);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Erro ao atualizar o usuário: " + ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<EventoDto>> DeletarEvento(int id)
        {
            var serviceResponse = new ServiceResponse<EventoDto>();

            try
            {
                var tipoUsurio = await _context.EventoModel.FirstOrDefaultAsync(x => x.ID == id);
                if (tipoUsurio == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Usuário não encontrado.";
                    return serviceResponse;
                }
                _context.EventoModel.Remove(tipoUsurio);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<EventoDto>(tipoUsurio);
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
