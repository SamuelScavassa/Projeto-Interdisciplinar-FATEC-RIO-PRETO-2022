using Projeto.Models;
namespace Projeto.Models;

public class Carrinho
{ 
    public int CarrinhoId { get; set; }
    public List<Produto>? Produtos { get; set; }
    public Cliente Cliente { get; set; }

}