using System;
using System.Collections.Generic;
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
    [AllowAnonymous]
    public class AnonymousController : ControllerBase
    {
        MovieListOperation movie = new MovieListOperation();
        public List<MovieList> Get()
        {
            return movie.GetMovieList();
        }
    }
}