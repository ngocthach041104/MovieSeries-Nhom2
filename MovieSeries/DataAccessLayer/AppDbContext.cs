using Microsoft.EntityFrameworkCore;
using Pj.CoreLayer.Entities;

namespace FilmSeriesReview.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        // DbSet ánh xạ đến Entity
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MovieSeriesTag> MovieSeriesTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapping cho Movie -> bảng MoviesSeries
            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("MoviesSeries");
                entity.HasKey(e => e.Id).HasName("PK_MoviesSeries");
                entity.Property(e => e.Id).HasColumnName("movie_series_id");
                entity.Property(e => e.Title).HasColumnName("title").IsRequired();
                entity.Property(e => e.Genre).HasColumnName("genre");
                entity.Property(e => e.ReleaseDate).HasColumnName("release_date");
                entity.Property(e => e.Description).HasColumnName("description");
            });

            // Mapping cho Review -> bảng Reviews
            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("Reviews");
                entity.HasKey(e => e.Id).HasName("PK_Reviews");
                entity.Property(e => e.Id).HasColumnName("review_id");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.MovieId).HasColumnName("movie_series_id");
                entity.Property(e => e.ReviewText).HasColumnName("review_text");
                entity.Property(e => e.ReviewDate).HasColumnName("review_date")
                      .HasDefaultValueSql("GETDATE()");

                entity.HasOne(d => d.User)
                      .WithMany(p => p.Reviews)
                      .HasForeignKey(d => d.UserId)
                      .OnDelete(DeleteBehavior.Cascade)
                      .HasConstraintName("FK_Reviews_Users");

                entity.HasOne(d => d.Movie)
                      .WithMany(p => p.Reviews)
                      .HasForeignKey(d => d.MovieId)
                      .OnDelete(DeleteBehavior.Cascade)
                      .HasConstraintName("FK_Reviews_MoviesSeries");
            });

            // Mapping cho Rating -> bảng Ratings
            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("Ratings");
                entity.HasKey(e => e.Id).HasName("PK_Ratings");
                entity.Property(e => e.Id).HasColumnName("rating_id");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.MovieId).HasColumnName("movie_series_id");
                entity.Property(e => e.Value).HasColumnName("rating");  // DB cột rating DECIMAL(3,2)

                entity.HasOne(d => d.User)
                      .WithMany(p => p.Ratings)
                      .HasForeignKey(d => d.UserId)
                      .OnDelete(DeleteBehavior.Cascade)
                      .HasConstraintName("FK_Ratings_Users");

                entity.HasOne(d => d.Movie)
                      .WithMany(p => p.Ratings)
                      .HasForeignKey(d => d.MovieId)
                      .OnDelete(DeleteBehavior.Cascade)
                      .HasConstraintName("FK_Ratings_MoviesSeries");
            });

            // Mapping cho Tag -> bảng Tags
            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("Tags");
                entity.HasKey(e => e.Id).HasName("PK_Tags");
                entity.Property(e => e.Id).HasColumnName("tag_id");
                entity.Property(e => e.TagName).HasColumnName("tag_name").IsRequired();
            });

            // Mapping cho User -> bảng Users
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(e => e.Id).HasName("PK_Users");
                entity.Property(e => e.Id).HasColumnName("user_id");
                entity.Property(e => e.Username).HasColumnName("username").IsRequired();
                entity.Property(e => e.Email).HasColumnName("email").IsRequired();
                entity.Property(e => e.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("GETDATE()");
            });

            // Mapping cho MovieSeriesTag -> bảng MovieSeriesTags
            modelBuilder.Entity<MovieSeriesTag>(entity =>
            {
                entity.ToTable("MovieSeriesTags");
                entity.HasKey(e => new { e.MovieSeriesId, e.TagId });
                entity.Property(e => e.MovieSeriesId).HasColumnName("movie_series_id");
                entity.Property(e => e.TagId).HasColumnName("tag_id");

                entity.HasOne(d => d.Movie)
                      .WithMany(p => p.MovieSeriesTags)
                      .HasForeignKey(d => d.MovieSeriesId)
                      .OnDelete(DeleteBehavior.Cascade)
                      .HasConstraintName("FK_MovieSeriesTags_MoviesSeries");

                entity.HasOne(d => d.Tag)
                      .WithMany(p => p.MovieSeriesTags)
                      .HasForeignKey(d => d.TagId)
                      .OnDelete(DeleteBehavior.Cascade)
                      .HasConstraintName("FK_MovieSeriesTags_Tags");
            });

            modelBuilder.Entity<Movie>().ToTable("MoviesSeries"); // Đảm bảo tên đúng

            base.OnModelCreating(modelBuilder);
        }
    }
}
