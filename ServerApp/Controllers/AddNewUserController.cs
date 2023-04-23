using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerApp.Models;

namespace ServerApp.Controllers
{
    [ApiController]
    public class AddNewUserController : Controller
    { 
        [HttpPost]
        [Route("AddUser/")]
        public  IResult AddUser(newUser user)
        {
            using (DataBaseWorker db = new DataBaseWorker())
            {
                Console.WriteLine("Добавление пользователя:");
                Data.people = db.Users.ToList();
                User? person = Data.people.FirstOrDefault(p => p.Email == user.Email);

                if (person is not null) return Results.Json("Пользователь уже существует");

                person = new User(user.Email, user.Password);
                Data.people.Add(person);

                db.Users.Add(person);
                db.SaveChangesAsync();
                return Results.Json("Пользователь добавлен!");
            }
        }
    }
    public record class newUser(string Email, string Password);
}
