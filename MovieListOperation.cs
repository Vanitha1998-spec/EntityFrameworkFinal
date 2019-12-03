using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCruiserEFFramework.Model
{
    public class MovieListOperation
    {
        MovieCruiserContext db = new MovieCruiserContext();
        public List<MovieList> GetMovieList()
        {
            var getdata = db.MovieList.FromSql("GetMovieList");
            return getdata.ToList();
        }
        public void UpdateMovies(long id, MovieList value)
        {
            var result1 = db.Database.ExecuteSqlCommand("dbo.UpdateMovieList @ml_id,@ml_title,@ml_budget,@ml_active,@ml_date_of_launch,@ml_genre,@ml_has_teaser",
                new SqlParameter("@ml_id", id),
                new SqlParameter("@ml_title", value.MlTitle),
                new SqlParameter("@ml_budget", value.MlBudget),
                new SqlParameter("@ml_active", value.MlActive),
                new SqlParameter("@ml_date_of_launch", value.MlDateOfLaunch),
                new SqlParameter("@ml_genre", value.MlGenre),
                new SqlParameter("@ml_has_teaser", value.MlHasTeaser));
        }

        public List<MovieList> GetCustMovieList()
        {
            var getdata = db.MovieList.FromSql("getCustomerMovieItemList");
            return getdata.ToList();
        }

        public List<MovieList> GetFavorites(long id)
        {
            //FromSQL is for the SELECT
            var result1 = db.MovieList.FromSql("dbo.GetFavoDetailsById @ft_us_id",
                new SqlParameter("@ft_us_id", id));
            return result1.ToList();
        }

        public void AddToFavorites(long id)
        {

            long UserId = 1;
            var result = db.Database.ExecuteSqlCommand("dbo.InsertFavDetails @ft_us_id,@ft_ml_id",
                new SqlParameter("@ft_us_id", UserId),
                new SqlParameter("@ft_ml_id", id));
        }
        public void DeleteFavorite(long id)
        {
            long UserId = 1;
            var result = db.Database.ExecuteSqlCommand("dbo.DeleteFavorites @ft_us_id,@ft_ml_id",
                new SqlParameter("@ft_us_id", UserId),
                new SqlParameter("@ft_ml_id", id));
        }
    }
}
