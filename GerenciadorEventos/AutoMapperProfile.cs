namespace GerenciadorEventos
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UsuarioModel, UsuarioDto>().ReverseMap();
            CreateMap<TipoUsuarioModel, TipoUsuarioDto>().ReverseMap();
        }
    }
}