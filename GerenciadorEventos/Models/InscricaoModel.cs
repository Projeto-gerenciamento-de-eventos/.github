namespace GerenciadorEventos.Models
{
    public class InscricaoModel
    {
        public int ID { get; set; }
        public int EventoID { get; set; }
        public int UsuarioID { get; set; }
        public DateTime DataCadastro { get; set; }

        public EventoModel Evento { get; set; }
        public UsuarioModel Usuario { get; set; }
    }
}
