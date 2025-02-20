using System;

namespace Pj.CoreLayer.Entities
{
    public class Review
    {
        // review_id (PK IDENTITY)
        public int Id { get; set; }

        // movie_series_id (FK -> MoviesSeries)
        public int MovieId { get; set; }

        // user_id (FK -> Users)
        public int UserId { get; set; }

        // review_text (text)
        public string ReviewText { get; set; }

        // review_date (datetime default GETDATE())
        public DateTime ReviewDate { get; set; }

        // Điều hướng đến Movie
        public Movie Movie { get; set; }

        // Điều hướng đến User
        public User User { get; set; }
    }
}
