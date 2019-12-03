using System;
using System.Collections.Generic;

namespace MovieCruiserEFFramework.Model
{
    public partial class MovieList
    {
        public MovieList()
        {
            Favorites = new HashSet<Favorites>();
        }

        public long MlId { get; set; }
        public string MlTitle { get; set; }
        public decimal? MlBudget { get; set; }
        public string MlActive { get; set; }
        public DateTime? MlDateOfLaunch { get; set; }
        public string MlGenre { get; set; }
        public string MlHasTeaser { get; set; }

        public virtual ICollection<Favorites> Favorites { get; set; }
    }
}
