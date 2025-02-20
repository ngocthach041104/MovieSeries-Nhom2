using Xunit;
using MovieSeries.CommonLayer.Utilities;
using System.ComponentModel.DataAnnotations;

namespace MovieSeries.Tests.Utilities
{
    public class ValidatorTests
    {
        [Theory]
        [InlineData("test@example.com", true)]
        [InlineData("invalidemail", false)]
        [InlineData("another@test", false)]
        [InlineData("", false)]
        public void IsValidEmail_Test(string email, bool expected)
        {
            // Act
            bool result = Validator.IsValidEmail(email);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
