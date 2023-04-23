using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerApp.Models;

namespace ServerApp.Controllers
{
    [ApiController]
    public class TaskController : Controller
    {

        [HttpGet]
        [Route("CompletedTasks/{Email}")]
        public IResult GetCompletedTasks(string Email) {


            User? person = Data.people.FirstOrDefault(p => p.Email == Email);

            if (person is null) return Results.Json(-1);

            return Results.Json(person.CompletedTasks);
        }

        [HttpGet]
        [Route("ProgressTasks/{Email}")]
        public IResult GetProgressTasks(string Email)
        {

            User? person = Data.people.FirstOrDefault(p => p.Email == Email);

            if (person is null) return Results.Json(-1);

            return Results.Json(person.ProgressTasks);
        }

        [HttpDelete]
        [Route("ProgressTasks/{Email}/{Task}")]
        public  IResult GetProgressTasks(string Email, string Task)
        {

            User? person = Data.people.FirstOrDefault(p => p.Email == Email);


            person.ProgressTasks.Remove(Task);

            return Results.Json(person.ProgressTasks);
        }
        [HttpDelete]
        [Route("CompletedTasks/{Email}")]
        public IResult DeleteAllConfirmedTasks(string Email)
        {
            User? person = Data.people.FirstOrDefault(p => p.Email == Email);

            person.CompletedTasks.Clear();

            return Results.Json(person.CompletedTasks);
        }


        [HttpPost]
        [Route("CompletedTasks/")]
        public IResult GetCompletedTasks(Taskreq a)
        {
            User? person = Data.people.FirstOrDefault(p => p.Email == a.Email);
            person.ProgressTasks.Remove(a.Task);
            person.CompletedTasks.Add(a.Task);
           
            return Results.Json(person.ProgressTasks);
        }

        [HttpPut]
        [Route("ProgressTasks/")]
        public IResult AddProgressTask(Taskreq a)
        {
            User? person = Data.people.FirstOrDefault(p => p.Email == a.Email);
            person.ProgressTasks.Add(a.Task);
            return Results.Json(person.ProgressTasks);
        }
    }

    public record class Taskreq(string Email, string Task);
}
