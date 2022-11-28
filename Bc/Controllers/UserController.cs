using Microsoft.AspNetCore.Mvc;
using Projeto.Models;

namespace Projeto.Controllers;

[ApiController]
[Route("user")]
public class UserController: ControllerBase
{

    private DBProjeto db;

    public UserController(DBProjeto db)
    {
        this.db = db;
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult Read(int id)
    {
        var str = db.Users.FirstOrDefault(x => x.UserId == id);
        List<User> s = new List<User>();
        s.Add(str);
        return Ok(s.ToList());
        //return DayOfWeek(db.Users.FirstOrDefault(x => x.UserId == id));
    }

    [HttpGet]
    [Route("list")]
    public ActionResult ReadLista()
    {
        return Ok(db.Users.ToList());
    }

    [HttpPost]
    public ActionResult Create(User user)
    {
        db.Users.Add(user);
        db.SaveChanges();
        return Created(user.Name.ToString(), user);
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult Delete(int Id)
    {
        User? user = db.Users.Find(Id);
        if (user == null)
        {
            return NotFound();
        }
        db.Users.Remove(user);
        db.SaveChanges();
        return Ok();
    }

    [HttpPut]
    public ActionResult Update(User user)
    {
        User? up = db.Users.Find(user.UserId);
        if (up == null)
        {
            return NotFound();
        }
        up.Name = user.Name;
        up.Email = user.Email;
        up.Password = user.Password;
        db.SaveChanges();

        return Ok();
    }
}