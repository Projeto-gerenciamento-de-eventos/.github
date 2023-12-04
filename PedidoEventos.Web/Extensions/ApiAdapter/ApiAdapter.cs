namespace PedidoEventos.Web;
public class ApiAdapter
{
    private readonly ILogger<ApiAdapter> _logger;

    public ApiAdapter(ILogger<ApiAdapter> logger)
        {
            _logger = logger;
        }
}
