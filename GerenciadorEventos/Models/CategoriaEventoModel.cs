namespace GerenciadorEventos.Models
{
    public class CategoriaEventoModel
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public List<EventoModel> Eventos { get; set; }
    }
}
