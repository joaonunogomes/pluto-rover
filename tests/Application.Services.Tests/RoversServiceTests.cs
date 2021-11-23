using Application.Dto;
using CtorMock.Moq;
using Data.Repository;
using FluentAssertions;
using Infrastructure.CrossCutting.Rover;
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
        private readonly Guid ROVER_ID = Guid.NewGuid();

        public RoversServiceTests()
        {
            this.roverRepositoryMock = Mocker.MockOf<IRoverRepository>();
        }

        [Fact]
        public async Task CreateRover_DefaultBehaviour_ShouldReturnCreatedRover()
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

        [Fact]
        public async Task MoveRover_DefaultBehaviour_ShouldUpdateRover()
        {
            // Arrange
            var xMock = 35;
            var yMock = 3;
            var directionMock = RoverDirectionType.N;

            this.roverRepositoryMock
                .Setup(x => x.GetAsync(It.IsAny<Guid>()))
                .ReturnsAsync(new Rover(xMock, yMock, directionMock));

            this.roverRepositoryMock
                .Setup(x => x.UpdateAsync(It.IsAny<Guid>(), It.IsAny<Rover>()))
                .Returns(Task.CompletedTask);

            // Act
            await this.Subject.MoveRover(this.ROVER_ID, RoverCommand.F);

            // Assert
            this.roverRepositoryMock.Verify(x => x.GetAsync(this.ROVER_ID), Times.Once);
            this.roverRepositoryMock.Verify(x => x.UpdateAsync(
                this.ROVER_ID, 
                It.IsAny<Rover>()), 
                Times.Once);
        }

        [Fact]
        public async Task MoveRover_WhenRoverRepositoryGetAsyncThrowsException_ShouldThrowException()
        {
            // Arrange
            this.roverRepositoryMock
                .Setup(x => x.GetAsync(It.IsAny<Guid>()))
                .ThrowsAsync(new Exception());

            // Act
            Func<Task> act = async () => await this.Subject.MoveRover(this.ROVER_ID, RoverCommand.F);

            // Assert
            await act.Should().ThrowAsync<Exception>();
            this.roverRepositoryMock.Verify(x => x.GetAsync(this.ROVER_ID), Times.Once);
            this.roverRepositoryMock.Verify(x => x.UpdateAsync(
                this.ROVER_ID,
                It.IsAny<Rover>()),
                Times.Never);
        }

        [Fact]
        public async Task MoveRover_WhenRoverRepositoryUpdateAsyncThrowsException_ShouldThrowException()
        {
            // Arrange
            this.roverRepositoryMock
                .Setup(x => x.GetAsync(It.IsAny<Guid>()))
                .ReturnsAsync(new Rover());

            this.roverRepositoryMock
                .Setup(x => x.UpdateAsync(It.IsAny<Guid>(), It.IsAny<Rover>()))
                .ThrowsAsync(new Exception());

            // Act
            Func<Task> act = async () => await this.Subject.MoveRover(this.ROVER_ID, RoverCommand.F);

            // Assert
            await act.Should().ThrowAsync<Exception>();
            this.roverRepositoryMock.Verify(x => x.GetAsync(this.ROVER_ID), Times.Once);
            this.roverRepositoryMock.Verify(x => x.UpdateAsync(
                this.ROVER_ID,
                It.IsAny<Rover>()),
                Times.Once);
        }
    }
}
