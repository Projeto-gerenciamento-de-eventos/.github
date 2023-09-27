namespace GerenciadorEventos.Models
{

    public class ComentarioModel
    {
        public int ID { get; set; }
        public int EventoID { get; set; }
        public int UsuarioID { get; set; }
        public string TextoComentario { get; set; }
        public DateTime DataCadastro { get; set; }

    }

}
