using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ServerApp.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ServerApp.Controllers
{


    [ApiController]
    public class login : Controller
    {
        DataBaseWorker db = new DataBaseWorker();


        [HttpPost]
        [Route("login")]
        public IResult GetUser(LoginUser loginData)
        {
            using (DataBaseWorker db = new DataBaseWorker())
            Data.people =  db.Users.ToList();
            Console.WriteLine(Data.people);
            User? person = Data.people.FirstOrDefault(p => p.Email == loginData.Email && p.UserPassword == loginData.Password);

            if (person is null) return Results.Unauthorized();

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, person.Email) };
           
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            
            var response = new
            {
                token = encodedJwt,
                email = person.Email
     
            };
          
            return Results.Json(response);

        }
    }
}
