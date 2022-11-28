namespace Projeto.Models;

public class Cliente: User
{
    public string Rua { get; set; }
    public int Numero { get; set; }
    public int CEP { get; set; }
    public string Cidade { get; set; }
}