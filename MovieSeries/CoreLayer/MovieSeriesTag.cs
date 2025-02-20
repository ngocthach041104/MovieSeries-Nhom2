namespace Pj.CoreLayer.Entities
{
    public class MovieSeriesTag
    {
        // movie_series_id (FK -> MoviesSeries)
        public int MovieSeriesId { get; set; }

        // tag_id (FK -> Tags)
        public int TagId { get; set; }

        // Điều hướng
        public Movie Movie { get; set; }
        public Tag Tag { get; set; }
    }
}
