namespace GerenciadorEventos.Models
{
    public class EventoModel
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public string Local { get; set; }
        public int CapacidadeMaxima { get; set; }
        public int OrganizadorID { get; set; }
        public int CategoriaEventoID { get; set; }
    }
}
