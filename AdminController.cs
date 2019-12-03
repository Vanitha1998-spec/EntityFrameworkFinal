using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCruiserEFFramework.Model;

namespace MovieCruiserEFFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        MovieListOperation movie = new MovieListOperation();
        public List<MovieList> Get()
        {

            return movie.GetMovieList();
        }

        [HttpPut("{id}", Name = "Update Movie List")]
        public void Put(int id, [FromBody] MovieList value)
        {
            movie.UpdateMovies(id, value);
        }

    }
}