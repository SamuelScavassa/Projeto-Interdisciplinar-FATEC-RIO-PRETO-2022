using Microsoft.AspNetCore.Mvc;
using Projeto.Models;

namespace Projeto.Controllers;

[ApiController]
[Route("pedido")]
public class PedidoController: ControllerBase
{

    private DBProjeto db;

    public PedidoController(DBProjeto db)
    {
        this.db = db;
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult Read(int id)
    {
        var str = db.Pedidos.FirstOrDefault(x => x.PedidoId == id);
        List<Pedido> s = new List<Pedido>();
        s.Add(str);
        return Ok(s.ToList());
        //return DayOfWeek(db.Pedidos.FirstOrDefault(x => x.PedidoId == id));
    }

    [HttpGet]
    [Route("list")]
    public ActionResult ReadLista()
    {
        return Ok(db.Pedidos.ToList());
    }

    [HttpPost]
    public ActionResult Create(Pedido Pedido)
    {
        db.Pedidos.Add(Pedido);
        db.SaveChanges();
        return Created(Pedido.PedidoId.ToString(), Pedido);
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult Delete(int id)
    {
        Pedido? Pedido = db.Pedidos.FirstOrDefault(x => x.PedidoId == id);
        if (Pedido == null)
        {
            return NotFound();
        }
        db.Pedidos.Remove(Pedido);
        db.SaveChanges();
        return Ok();
    }

    [HttpPut]
    public ActionResult Update(Pedido Pedido)
    {
        Pedido? up = db.Pedidos.Find(Pedido.PedidoId);
        if (up == null)
        {
            return NotFound();
        }
        up.Cliente = Pedido.Cliente;
        up.Data = Pedido.Data;
        up.Produtos = Pedido.Produtos;
        db.SaveChanges();

        return Ok();
    }
}