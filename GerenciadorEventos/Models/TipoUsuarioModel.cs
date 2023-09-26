namespace GerenciadorEventos.Models
{
    public class TipoUsuarioModel
    {
        public int ID { get; set; }
        public string Nome { get; set; }

        public List<UsuarioModel> Usuarios { get; set; }
    }
}
