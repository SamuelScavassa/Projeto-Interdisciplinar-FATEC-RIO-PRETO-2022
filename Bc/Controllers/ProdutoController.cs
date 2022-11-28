using Microsoft.AspNetCore.Mvc;
using Projeto.Models;
using System.Text.Json;

namespace Projeto.Controllers;

[ApiController]
[Route("produto")]
public class ProdutoController: ControllerBase
{
    private DBProjeto db;

    public ProdutoController(DBProjeto db)
    {
        this.db = db;
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult Read(int id)
    {     
        var str = db.Produtos.FirstOrDefault(x => x.ProdutoId == id);
        List<Produto> s = new List<Produto>();
        s.Add(str);
        return Ok(s.ToList());
    }

    [HttpGet]
    [Route("lista")]
    public ActionResult ReadTudo()
    {     
        return Ok(db.Produtos.ToList());
    }

    [HttpPost]
    [Route("create")]
    public ActionResult Create(Produto pr)
    {   
        db.Produtos.Add(pr);
        db.SaveChanges(); 
        return Ok(pr);
    }

    [HttpPut]
    public ActionResult Update(Produto produto)
    {
        Produto? up = db.Produtos.Find(produto.ProdutoId);
        if (up == null)
            return NotFound();
        
        up.Nome = produto.Nome;
        up.Descricao = produto.Descricao;
        up.Preco = produto.Preco;
        up.Tag = produto.Tag;
        db.SaveChanges();

        return Ok("Updated");

    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult Delete (int id)
    {
        Produto? del = db.Produtos.Find(id);
        if (del == null)
            return NotFound();
        
        db.Produtos.Remove(del);
        db.SaveChanges();

        return Ok("Deleted");
    }

}