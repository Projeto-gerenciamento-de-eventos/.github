using GerenciadorEventos.Dtos;
using GerenciadorEventos.Models;

namespace GerenciadorEventos
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UsuarioModel, UsuarioDto>().ReverseMap();
            CreateMap<TipoUsuarioModel, TipoUsuarioDto>().ReverseMap();
            CreateMap<CategoriaEventoModel, CategoriaEventoDto>().ReverseMap();
            CreateMap<ComentarioModel, ComentarioDto>().ReverseMap();
            CreateMap<EventoModel, EventoDto>().ReverseMap();
            CreateMap<InscricaoModel, InscricaoDto>().ReverseMap();
        }
    }
}