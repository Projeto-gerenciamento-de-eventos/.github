using System.ComponentModel.DataAnnotations;

namespace GerenciadorEventos.Dtos
{
    public class UsuarioDto
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public int TipoUsuarioID { get; set; }
    }
}
