namespace Projeto.Models;

public class Pedido
{
    public int PedidoId { get; set; }
    public DateTime Data { get; set; }
    public string Cliente { get; set; }
    public string Produtos { get; set; }
    public double Total { get; set; }
}