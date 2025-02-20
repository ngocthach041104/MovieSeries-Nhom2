using Xunit;
using Moq;
using Pj.CoreLayer.Entities;
using Pj.RepositoryLayer.Interfaces;
using Pj.ServiceLayer.Services;

namespace MovieSeries.Tests.Services
{
    public class MovieServiceTests
    {
        private readonly Mock<IMovieRepository> _repositoryMock;
        private readonly MovieService _movieService;
        public MovieServiceTests()
        {
            // Khởi tạo mock
            _repositoryMock = new Mock<IMovieRepository>();

            // Truyền mock vào constructor của MovieService
            _movieService = new MovieService(_repositoryMock.Object);
        }
        [Fact]
        public void AddMovie_ShouldReturnTrue_WhenMovieIsValid()
        {
            // Arrange
            var movie = new Movie { Title = "Inception", Genre = "Sci-Fi" };
            _repositoryMock.Setup(repo => repo.Add(movie)).Returns(true);

            // Act
            var result = _movieService.AddMovie(movie);

            // Assert
            Assert.True(result);
        }
    }
}
