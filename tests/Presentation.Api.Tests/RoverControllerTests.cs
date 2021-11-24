using CtorMock.Moq;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using PlutoRover.Application.Dto;
using PlutoRover.Application.Services;
using PlutoRover.ClimbingApi.Presentation.Api.Controllers;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PlutoRover.Presentation.Api.Tests
{
    public class RoverControllerTests : MockBase<RoversController>
    {
        private readonly Mock<IRoversService> roversServiceMock;
        private readonly Mock<ILogger<RoversController>> loggerMock;

        private readonly Guid ROVER_ID = Guid.NewGuid();

        public RoverControllerTests()
        {
            this.roversServiceMock = Mocker.MockOf<IRoversService>();
            this.loggerMock = Mocker.MockOf<ILogger<RoversController>>();
        }

        [Fact]
        public async Task PostAsync_DefaultBehaviour_ShouldReturnCreatedRover()
        {
            // Arrange
            var roverMock = new Rover();

            this.roversServiceMock
                .Setup(x => x.CreateRoverAsync(It.IsAny<Rover>()))
                .ReturnsAsync(new Rover());

            // Act
            var act = await this.Subject.PostAsync(roverMock);

            // Assert
            act.Should().BeOfType(typeof(CreatedAtActionResult));
            this.roversServiceMock.Verify(x => x.CreateRoverAsync(roverMock), Times.Once);
        }

        [Fact]
        public async Task PostAsync_WhenRoversServiceThrowsException_ShouldThrowException()
        {
            // Arrange
            var roverMock = new Rover();

            this.roversServiceMock
                .Setup(x => x.CreateRoverAsync(It.IsAny<Rover>()))
                .ThrowsAsync(new Exception());

            // Act
            var act = await this.Subject.PostAsync(roverMock);

            // Assert
            act.Should().BeOfType(typeof(BadRequestObjectResult));
            this.roversServiceMock.Verify(x => x.CreateRoverAsync(roverMock), Times.Once);
        }

        [Fact]
        public async Task GetAsync_DefaultBehaviour_ShouldReturnRover()
        {
            // Arrange
            this.roversServiceMock
                .Setup(x => x.GetRoverAsync(It.IsAny<Guid>()))
                .ReturnsAsync(new Rover { Id = this.ROVER_ID });

            // Act
            var act = await this.Subject.GetAsync(this.ROVER_ID);

            // Assert
            act.Should().BeOfType(typeof(OkObjectResult));
            this.roversServiceMock.Verify(x => x.GetRoverAsync(this.ROVER_ID), Times.Once);
        }

        [Fact]
        public async Task GetAsync_WhenRoversServiceThrowsException_ShouldReturnBadRequest()
        {
            // Arrange
            this.roversServiceMock
                .Setup(x => x.GetRoverAsync(It.IsAny<Guid>()))
                .ThrowsAsync(new Exception());

            // Act
            var act = await this.Subject.GetAsync(this.ROVER_ID);

            // Assert
            act.Should().BeOfType(typeof(BadRequestObjectResult));
            this.roversServiceMock.Verify(x => x.GetRoverAsync(this.ROVER_ID), Times.Once);
        }

        [Fact]
        public async Task MoveAsync_WhenMovingForward_ShouldUpdateRoverWithSameCommand()
        {
            // Arrange
            this.roversServiceMock
                .Setup(x => x.MoveRoverAsync(It.IsAny<Guid>(), It.IsAny<RoverCommand>()))
                .Returns(Task.CompletedTask);

            // Act
            var act = await this.Subject.MoveAsync(this.ROVER_ID, RoverCommand.F);

            // Assert
            act.Should().BeOfType(typeof(NoContentResult));
            this.roversServiceMock.Verify(x => x.MoveRoverAsync(this.ROVER_ID, RoverCommand.F), Times.Once);
        }

        [Fact]
        public async Task MoveAsync_WhenMovingBackwards_ShouldUpdateRoverWithSameCommand()
        {
            // Arrange
            this.roversServiceMock
                .Setup(x => x.MoveRoverAsync(It.IsAny<Guid>(), It.IsAny<RoverCommand>()))
                .Returns(Task.CompletedTask);

            // Act
            var act = await this.Subject.MoveAsync(this.ROVER_ID, RoverCommand.B);

            // Assert
            act.Should().BeOfType(typeof(NoContentResult));
            this.roversServiceMock.Verify(x => x.MoveRoverAsync(this.ROVER_ID, RoverCommand.B), Times.Once);
        }

        [Fact]
        public async Task MoveAsync_WhenMovingRight_ShouldUpdateRoverWithSameCommand()
        {
            // Arrange
            this.roversServiceMock
                .Setup(x => x.MoveRoverAsync(It.IsAny<Guid>(), It.IsAny<RoverCommand>()))
                .Returns(Task.CompletedTask);

            // Act
            var act = await this.Subject.MoveAsync(this.ROVER_ID, RoverCommand.R);

            // Assert
            act.Should().BeOfType(typeof(NoContentResult));
            this.roversServiceMock.Verify(x => x.MoveRoverAsync(this.ROVER_ID, RoverCommand.R), Times.Once);
        }

        [Fact]
        public async Task MoveAsync_WhenMovingLeft_ShouldUpdateRoverWithSameCommand()
        {
            // Arrange
            this.roversServiceMock
                .Setup(x => x.MoveRoverAsync(It.IsAny<Guid>(), It.IsAny<RoverCommand>()))
                .Returns(Task.CompletedTask);

            // Act
            var act = await this.Subject.MoveAsync(this.ROVER_ID, RoverCommand.L);

            // Assert
            act.Should().BeOfType(typeof(NoContentResult));
            this.roversServiceMock.Verify(x => x.MoveRoverAsync(this.ROVER_ID, RoverCommand.L), Times.Once);
        }

        [Fact]
        public async Task MoveAsync_WhenRoversServiceThrowsException_ShouldReturnBadRequestAndLogThatException()
        {
            // Arrange
            var errorMessage = "This is some error message";

            this.roversServiceMock
                .Setup(x => x.MoveRoverAsync(It.IsAny<Guid>(), It.IsAny<RoverCommand>()))
                .ThrowsAsync(new Exception(errorMessage));

            // Act
            var act = await this.Subject.MoveAsync(this.ROVER_ID, RoverCommand.L);

            // Assert
            act.Should().BeOfType(typeof(BadRequestObjectResult));
            this.roversServiceMock.Verify(x => x.MoveRoverAsync(this.ROVER_ID, RoverCommand.L), Times.Once);
            this.loggerMock.Verify(
                logger => logger.Log(
                    It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
                    It.IsAny<EventId>(),
                    It.IsAny<It.IsAnyType>(),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()), Times.Once);
        }
    }
}
