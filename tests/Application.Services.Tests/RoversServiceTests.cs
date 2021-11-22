using Application.Dto;
using CtorMock.Moq;
using FluentAssertions;
using PlutoRover.Application.Services;
using Xunit;


namespace Application.Services.Tests
{
    public class RoversServiceTests : MockBase<IRoversService>
    {
        [Fact]
        public void CreateRover_WhenValidRoverIsProvided_ShouldReturnCreatedRover()
        {
            // Arrange
            var rover = new Rover();

            // Act
            var act = this.Subject.CreateRover(rover);

            // Assert
            act.Should().NotBeNull();
            act.Should().BeOfType(typeof(Rover));
        }
    }
}
