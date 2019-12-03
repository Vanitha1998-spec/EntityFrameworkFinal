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
    [Authorize(Roles = "Customer")]
    public class CustomerController : ControllerBase
    {
        MovieListOperation movie = new MovieListOperation();
        public List<MovieList> Get()
        {

            return movie.GetCustMovieList();

        }
        [HttpGet("{id}", Name = "custGet")]
        public List<MovieList> Get(int id)
        {
            return movie.GetFavorites(id);

        }
        [HttpPost("{id}")]
        public void Post(int id)
        {
            movie.AddToFavorites(id);

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            movie.DeleteFavorite(id);
        }
    }
}
