using Xunit;
using Moq;
using Pj.CoreLayer.Entities;
using Pj.RepositoryLayer.Interfaces;
using Pj.ServiceLayer.Services;

namespace MovieSeries.Tests.Services
{
    public class MovieServiceTests
    {


        public MovieServiceTests()
        {
            // Khởi tạo mock
            _repositoryMock = new Mock<IMovieRepository>();

            // Truyền mock vào constructor của MovieService
            _movieService = new MovieService(_repositoryMock.Object);
        }

    }
}
