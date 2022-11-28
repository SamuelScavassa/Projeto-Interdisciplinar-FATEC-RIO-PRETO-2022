using Microsoft.AspNetCore.Mvc;
using Projeto.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Projeto.Controllers;

[ApiController]
[Route("carrinho")]
public class CarrinhoController: ControllerBase
{

    private DBProjeto db;

    public CarrinhoController(DBProjeto db)
    {
        this.db = db;
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult Read(int id)
    {
        var str = db.Carrinhos.FirstOrDefault(x => x.Cliente.UserId == id);
        //List<Carrinho> s = new List<Carrinho>();
        //s.Add(str);
        //return Ok(s.ToList());

        return Ok(str);
    }

    [HttpGet]
    [Route("lista")]
    public ActionResult ReadLista()
    {
        //List<Carrinho> s = new List<Carrinho>();
        //s.Add(str);
        //return Ok(s.ToList());
        return Ok(db.Carrinhos.ToList());
    }

    [HttpPost]
    public ActionResult Create(Carrinho carrinho)
    {
        var x = new Carrinho{
            Produtos = carrinho.Produtos,
            Cliente = carrinho.Cliente,
            CarrinhoId = carrinho.CarrinhoId
        };
        
        db.Carrinhos.Add(x);
        db.SaveChanges();
        return Ok(carrinho);
    }

    [HttpPut]
    public ActionResult Update(Carrinho carrinho)
    {   
        Carrinho? car = db.Carrinhos.Find(carrinho.CarrinhoId);
        if (car == null)
            return NotFound();

        car.Cliente = carrinho.Cliente;
        car.Produtos = carrinho.Produtos;
        db.SaveChanges();
        return Ok(carrinho);
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult Delete(int id)
    {
        Carrinho? car = db.Carrinhos.Find(id);
        if (car == null)
            return NotFound();

        db.Carrinhos.Remove(car);
        db.SaveChanges();
        return Ok();
    }


}