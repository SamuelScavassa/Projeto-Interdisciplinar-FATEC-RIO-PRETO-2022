using Microsoft.EntityFrameworkCore;

namespace Projeto.Models;
public class DBProjeto: DbContext
{
    public DBProjeto(DbContextOptions<DBProjeto> options) : base(options)
    {
    }
    


    public DbSet<User>? Users { get; set; }
    public DbSet<Produto>? Produtos { get; set; }
    public DbSet<Carrinho>? Carrinhos { get; set; }
    public DbSet<Cliente>? Clientes { get; set; }
    public DbSet<Funcionario>? Funcionarios { get; set; }
    public DbSet<Pedido>? Pedidos { get; set; }
}