namespace GerenciadorEventos.Models
{
    public class UsuarioModel
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public int TipoUsuarioID { get; set; }

        public TipoUsuarioModel TipoUsuario { get; set; }
        public List<EventoModel> EventosOrganizados { get; set; }
        public List<InscricaoModel> Inscricoes { get; set; }
        public List<ComentarioModel> Comentarios { get; set; }
    }
}
