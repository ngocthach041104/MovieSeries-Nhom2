using System;
using System.Collections.Generic;

namespace Pj.CoreLayer.Entities
{
    public class Movie
    {
        // movie_series_id (PK IDENTITY)
        public int Id { get; set; }

        // title (NOT NULL)
        public string Title { get; set; }

        // genre (có thể NULL)
        public string Genre { get; set; }

        // release_date (có thể NULL)
        public DateTime? ReleaseDate { get; set; }

        // description (text, có thể NULL)
        public string Description { get; set; }

        // Quan hệ n-n với Tag qua MovieSeriesTag
        public ICollection<MovieSeriesTag> MovieSeriesTags { get; set; }

        // Quan hệ 1-n với Reviews
        public ICollection<Review> Reviews { get; set; }

        // Quan hệ 1-n với Ratings
        public ICollection<Rating> Ratings { get; set; }
    }
}
