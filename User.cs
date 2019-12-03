using System;
using System.Collections.Generic;

namespace MovieCruiserEFFramework.Model
{
    public partial class Users
    {
        public Users()
        {
            Favorites = new HashSet<Favorites>();
        }

        public long UsId { get; set; }
        public string UsName { get; set; }

        public virtual ICollection<Favorites> Favorites { get; set; }
    }
}
