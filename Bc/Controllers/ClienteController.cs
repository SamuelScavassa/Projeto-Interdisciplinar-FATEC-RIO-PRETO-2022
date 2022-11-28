using Microsoft.AspNetCore.Mvc;
using Projeto.Models;

namespace Projeto.Controllers;

[ApiController]
[Route("cliente")]
public class ClienteController: ControllerBase
{

    private DBProjeto db;

    public ClienteController(DBProjeto db)
    {
        this.db = db;
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult Read(int id)
    {
        var str = db.Clientes.FirstOrDefault(x => x.UserId == id);
        List<Cliente> s = new List<Cliente>();
        s.Add(str);
        return Ok(s.ToList());
        //return DayOfWeek(db.Clientes.FirstOrDefault(x => x.ClienteId == id));
    }

    [HttpGet]
    [Route("list")]
    public ActionResult ReadLista()
    {
        return Ok(db.Clientes.ToList());
    }

    [HttpPost]
    public ActionResult Create(Cliente Cliente)
    {
        db.Clientes.Add(Cliente);
        db.SaveChanges();
        return Created(Cliente.Name.ToString(), Cliente);
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult Delete(int Id)
    {
        Cliente? Cliente = db.Clientes.FirstOrDefault(x => x.UserId == Id);
        if (Cliente == null)
        {
            return NotFound();
        }
        db.Clientes.Remove(Cliente);
        db.SaveChanges();
        return Ok();
    }

    [HttpPut]
    public ActionResult Update(Cliente Cliente)
    {
        Cliente? up = db.Clientes.FirstOrDefault(x => x.UserId == Cliente.UserId);
        if (up == null)
        {
            return NotFound();
        }
        up.Name = Cliente.Name;
        up.Email = Cliente.Email;
        up.Password = Cliente.Password;
        up.Rua = Cliente.Rua;
        up.Numero = Cliente.Numero;
        up.CEP = Cliente.CEP;
        up.Cidade = Cliente.Cidade;
        db.SaveChanges();

        return Ok();
    }
}