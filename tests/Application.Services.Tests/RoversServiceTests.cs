using Application.Dto;
using CtorMock.Moq;
using Data.Repository;
using FluentAssertions;
using Moq;
using PlutoRover.Application.Services;
using System;
using System.Threading.Tasks;
using Xunit;


namespace Application.Services.Tests
{
    public class RoversServiceTests : MockBase<RoversService>
    {
        private readonly Mock<IRoverRepository> roverRepositoryMock;

        public RoversServiceTests()
        {
            this.roverRepositoryMock = Mocker.MockOf<IRoverRepository>();
        }

        [Fact]
        public async Task CreateRover_WhenValidRoverIsProvided_ShouldReturnCreatedRover()
        {
            // Arrange
            var rover = new Rover();

            this.roverRepositoryMock
                .Setup(x => x.AddAsync(It.IsAny<Rover>()))
                .Returns(Task.CompletedTask);

            // Act
            var act = await this.Subject.CreateRover(rover);

            // Assert
            act.Should().NotBeNull();
            act.Should().BeOfType(typeof(Rover));
            act.Id.Should().NotBeEmpty();
            this.roverRepositoryMock.Verify(x => x.AddAsync(rover), Times.Once);

        }

        [Fact]
        public async Task CreateRover_WhenRepositoryThrowsException_ShouldThrowException()
        {
            // Arrange
            var rover = new Rover();

            this.roverRepositoryMock
                .Setup(x => x.AddAsync(It.IsAny<Rover>()))
                .ThrowsAsync(new Exception());

            // Act
            Func<Task> act = async () => await this.Subject.CreateRover(rover);

            // Assert
            await act.Should().ThrowAsync<Exception>();
            this.roverRepositoryMock.Verify(x => x.AddAsync(rover), Times.Once);
        }
    }
}
