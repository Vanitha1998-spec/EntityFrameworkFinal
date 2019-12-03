using System;
using System.Collections.Generic;

namespace MovieCruiserEFFramework.Model
{
    public partial class Favorites
    {
        public int FtId { get; set; }
        public long? FtUsId { get; set; }
        public long? FtMlId { get; set; }

        public virtual MovieList FtMl { get; set; }
        public virtual Users FtUs { get; set; }
    }
}
