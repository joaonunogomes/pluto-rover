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

        [Fact]
        public async Task MoveRover_WhenPointingNorthAndRoverIsNotAtGridLimitAndMovingForwardOneTime_ShouldUpdateRoverXPosition()
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
                It.Is<Rover>(rover => rover.X == xMock + 1 && rover.Y == yMock && rover.Direction == RoverDirectionType.N)), 
                Times.Once);
        }

        [Fact]
        public async Task MoveRover_WhenPointingNorthAndRoverIsAtGridLimitAndMovingForwardOneTime_ShouldUpdateRoverToDefaultXPosition()
        {
            // Arrange
            var xMock = PlutoSettings.GridSize;
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
                It.Is<Rover>(rover => rover.X == default && rover.Y == yMock && rover.Direction == RoverDirectionType.N)),
                Times.Once);
        }

        [Fact]
        public async Task MoveRover_WhenPointingNorthAndRoverIsNotAtGridLimitAndMovingBackwardsOneTime_ShouldUpdateRoverXPosition()
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
            await this.Subject.MoveRover(this.ROVER_ID, RoverCommand.B);

            // Assert
            this.roverRepositoryMock.Verify(x => x.GetAsync(this.ROVER_ID), Times.Once);
            this.roverRepositoryMock.Verify(x => x.UpdateAsync(
                this.ROVER_ID,
                It.Is<Rover>(rover => rover.X == xMock - 1 && rover.Y == yMock && rover.Direction == RoverDirectionType.N)),
                Times.Once);
        }

        [Fact]
        public async Task MoveRover_WhenPointingNorthAndRoverIsAtGridLimitAndMovingBackwardsOneTime_ShouldUpdateRoverToTheEndOfXPosition()
        {
            // Arrange
            var xMock = default(int);
            var yMock = 3;
            var directionMock = RoverDirectionType.N;

            this.roverRepositoryMock
                .Setup(x => x.GetAsync(It.IsAny<Guid>()))
                .ReturnsAsync(new Rover(xMock, yMock, directionMock));

            this.roverRepositoryMock
                .Setup(x => x.UpdateAsync(It.IsAny<Guid>(), It.IsAny<Rover>()))
                .Returns(Task.CompletedTask);

            // Act
            await this.Subject.MoveRover(this.ROVER_ID, RoverCommand.B);

            // Assert
            this.roverRepositoryMock.Verify(x => x.GetAsync(this.ROVER_ID), Times.Once);
            this.roverRepositoryMock.Verify(x => x.UpdateAsync(
                this.ROVER_ID,
                It.Is<Rover>(rover => rover.X == PlutoSettings.GridSize && rover.Direction == RoverDirectionType.N)),
                Times.Once);
        }

        [Fact]
        public async Task MoveRover_WhenPointingNorthAndMovingRight_ShouldUpdateRoverDirectionToEast()
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
            await this.Subject.MoveRover(this.ROVER_ID, RoverCommand.R);

            // Assert
            this.roverRepositoryMock.Verify(x => x.GetAsync(this.ROVER_ID), Times.Once);
            this.roverRepositoryMock.Verify(x => x.UpdateAsync(
                this.ROVER_ID,
                It.Is<Rover>(rover => rover.X == xMock && rover.Y == yMock && rover.Direction == RoverDirectionType.E)),
                Times.Once);
        }

        [Fact]
        public async Task MoveRover_WhenPointingNorthAndMovingLeft_ShouldUpdateRoverDirectionToWest()
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
            await this.Subject.MoveRover(this.ROVER_ID, RoverCommand.L);

            // Assert
            this.roverRepositoryMock.Verify(x => x.GetAsync(this.ROVER_ID), Times.Once);
            this.roverRepositoryMock.Verify(x => x.UpdateAsync(
                this.ROVER_ID,
                It.Is<Rover>(rover => rover.X == xMock && rover.Y == yMock && rover.Direction == RoverDirectionType.W)),
                Times.Once);
        }
    }
}
