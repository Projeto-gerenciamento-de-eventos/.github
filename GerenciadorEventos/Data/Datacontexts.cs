namespace GerenciadorEventos;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<UsuarioModel> UsuarioModel => Set<UsuarioModel>();
    public DbSet<CategoriaEventoModel> CategoriaEventoModel => Set<CategoriaEventoModel>();
    public DbSet<ComentarioModel> ComentarioModel => Set<ComentarioModel>();
    public DbSet<EventoModel> EventoModel => Set<EventoModel>();
    public DbSet<InscricaoModel> InscricaoModel => Set<InscricaoModel>();
    public DbSet<TipoUsuarioModel> TipoUsuarioModel => Set<TipoUsuarioModel>();
}
