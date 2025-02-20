using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;
using System.Collections.Generic;
using Pj.API.Controllers;
using Pj.CoreLayer.Entities;
using Pj.ServiceLayer.Interfaces;

namespace MovieSeries.Tests.Controllers
{
    public class MovieControllerTests
    {
        private readonly Mock<IMovieService> _serviceMock;
        private readonly MovieController _controller;

        public MovieControllerTests()
        {
            _serviceMock = new Mock<IMovieService>();
            _controller = new MovieController(_serviceMock.Object);
        }

        [Fact]
        public async Task GetMovie_ReturnsNotFound_WhenMovieIsNull()
        {
            // Arrange
            _serviceMock.Setup(s => s.GetMovieByIdAsync(1))
                        .ReturnsAsync((Movie)null);

            // Act
            var result = await _controller.GetMovie(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetMovie_ReturnsOkObjectResult_WhenMovieIsFound()
        {
            // Arrange
            var movie = new Movie { Title = "Inception", Genre = "Sci-Fi" };
            _serviceMock.Setup(s => s.GetMovieByIdAsync(1))
                        .ReturnsAsync(movie);

            // Act
            var result = await _controller.GetMovie(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(movie, okResult.Value);
        }
    }
}