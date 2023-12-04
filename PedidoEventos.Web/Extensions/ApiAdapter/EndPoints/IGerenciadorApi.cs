

using Refit;

namespace PedidoEventos.Web;
public interface IGerenciadorApi
{
    [Post("/v1/tribunal/executar-evento")]
    Task ExecutarEvento(string execucao);

}
