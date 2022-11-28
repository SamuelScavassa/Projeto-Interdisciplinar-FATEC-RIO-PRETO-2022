using Microsoft.AspNetCore.Mvc;
using Projeto.Models;

namespace Projeto.Controllers;

[ApiController]
[Route("funcionario")]
public class FuncionarioController: ControllerBase
{

    private DBProjeto db;

    public FuncionarioController(DBProjeto db)
    {
        this.db = db;
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult Read(int id)
    {
        var str = db.Funcionarios.FirstOrDefault(x => x.UserId == id);
        List<Funcionario> s = new List<Funcionario>();
        s.Add(str);
        return Ok(s.ToList());
        //return DayOfWeek(db.Funcionarios.FirstOrDefault(x => x.FuncionarioId == id));
    }

    [HttpGet]
    [Route("list")]
    public ActionResult ReadLista()
    {
        return Ok(db.Funcionarios.ToList());
    }

    [HttpPost]
    public ActionResult Create(Funcionario Funcionario)
    {
        db.Funcionarios.Add(Funcionario);
        db.SaveChanges();
        return Created(Funcionario.Name.ToString(), Funcionario);
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult Delete(int Id)
    {
        Funcionario? Funcionario = db.Funcionarios.FirstOrDefault(x => x.UserId == Id);;
        if (Funcionario == null)
        {
            return NotFound();
        }
        db.Funcionarios.Remove(Funcionario);
        db.SaveChanges();
        return Ok();
    }

    [HttpPut]
    public ActionResult Update(Funcionario Funcionario)
    {
        Funcionario? up = db.Funcionarios.Find(Funcionario.UserId);
        if (up == null)
        {
            return NotFound();
        }
        up = Funcionario;
        db.SaveChanges();

        return Ok();
    }
}