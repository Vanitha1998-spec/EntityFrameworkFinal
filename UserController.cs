using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCruiserEFFramework.Model;

namespace MovieCruiserWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //AuthController auth = new AuthController();
        //string connectionValue = "Data Source=PC430723;Initial Catalog=MovieCruiser;Integrated Security=true";
        MovieCruiserContext db = new MovieCruiserContext();
        // GET: api/User
        [HttpGet("{id}")]
        public string Get(int id, [FromBody] Users2 value)
        {
            var loginUser = db.Users2.FromSql("SpLogin @us_id,@us_password",
                new SqlParameter("@us_id", id),
                new SqlParameter("@us_password", value.UsPassword));
            Users2 user = new Users2();
            foreach (var item in loginUser)
            {
                user.UsId = item.UsId;
                user.UsName = item.UsName;
                string userRole;
                if (user.UsId == 1)
                    userRole = "Admin";
                else
                    userRole = "Customer";

                return AuthController.GenerateJSONWebToken(user.UsId, userRole);
            }
            return "Invalid User";
        }
        [HttpPost(Name = "InsertUser")]
        public void Post([FromBody] Users2 value)
        {
            db.Database.ExecuteSqlCommand("SpSignUp @us_name,@us_password",
                new SqlParameter("@us_name", value.UsName),
                new SqlParameter("@us_password", value.UsPassword));
        }

    }
}
