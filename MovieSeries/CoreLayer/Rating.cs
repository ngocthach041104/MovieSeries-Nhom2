namespace Pj.CoreLayer.Entities
{
    public class Rating
    {
        // rating_id (PK IDENTITY)
        public int Id { get; set; }

        // movie_series_id (FK -> MoviesSeries)
        public int MovieId { get; set; }

        // user_id (FK -> Users)
        public int UserId { get; set; }

        // rating (decimal(3,2), CHECK 0 <= rating <= 10)
        public decimal Value { get; set; }

        // Điều hướng đến Movie
        public Movie Movie { get; set; }

        // Điều hướng đến User
        public User User { get; set; }
    }
}
