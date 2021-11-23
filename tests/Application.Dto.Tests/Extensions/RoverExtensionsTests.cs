using Application.Dto.Extensions;
using FluentAssertions;
using Infrastructure.CrossCutting.Rover;
using Xunit;

namespace Application.Dto.Tests.Extensions
{
    public class RoverExtensionsTests
    {
        [Fact]
        public void MoveRoverWhenPointingNorth_WhenMovingForwardAndCurrentRoverYValueIsNotAtGridLimit_ShouldIncreaseYValueByOne()
        {
            // Arrange
            var xMock = 3;
            var yMock = 35;
            var directionMock = RoverDirectionType.N;

            var rover = new Rover(xMock, yMock, directionMock);

            // Act
            rover.MoveRoverWhenPointingNorth(RoverCommand.F);

            // Assert 
            rover.Should().NotBeNull();
            rover.X.Should().Be(xMock);
            rover.Y.Should().Be(yMock + 1);
            rover.Direction.Should().Be(directionMock);
        }

        [Fact]
        public void MoveRoverWhenPointingNorth_WhenMovingBackwardsAndCurrentRoverYValueIsNotAtGridLimit_ShouldDecreaseYValueByOne()
        {
            // Arrange
            var xMock = 3;
            var yMock = 35;
            var directionMock = RoverDirectionType.N;

            var rover = new Rover(xMock, yMock, directionMock);

            // Act
            rover.MoveRoverWhenPointingNorth(RoverCommand.B);

            // Assert 
            rover.Should().NotBeNull();
            rover.X.Should().Be(xMock);
            rover.Y.Should().Be(yMock - 1);
            rover.Direction.Should().Be(directionMock);
        }

        [Fact]
        public void MoveRoverWhenPointingNorth_WhenMovingForwardAndCurrentRoverYValueIsAtGridLimit_ShouldSetYValueToGridBeginning()
        {
            // Arrange
            var xMock = 3;
            var yMock = PlutoSettings.GridSize;
            var directionMock = RoverDirectionType.N;

            var rover = new Rover(xMock, yMock, directionMock);

            // Act
            rover.MoveRoverWhenPointingNorth(RoverCommand.F);

            // Assert
            rover.Should().NotBeNull();
            rover.X.Should().Be(xMock);
            rover.Y.Should().Be(default);
            rover.Direction.Should().Be(directionMock);
        }

        [Fact]
        public void MoveRoverWhenPointingNorth_WhenMovingBackwardsAndCurrentRoverYValueIsAtGridBeginning_ShouldSetYValueToGridLimit()
        {
            // Arrange
            var xMock = 3;
            var yMock = default(int);
            var directionMock = RoverDirectionType.N;

            var rover = new Rover(xMock, yMock, directionMock);

            // Act
            rover.MoveRoverWhenPointingNorth(RoverCommand.B);

            // Assert
            rover.Should().NotBeNull();
            rover.X.Should().Be(xMock);
            rover.Y.Should().Be(PlutoSettings.GridSize);
            rover.Direction.Should().Be(directionMock);
        }

        [Fact]
        public void MoveRoverWhenPointingNorth_WhenRotatingRoverToRight_ShouldUpdateRoverDirectionToEast()
        {
            // Arrange
            var xMock = 35;
            var yMock = 3;
            var directionMock = RoverDirectionType.N;

            var rover = new Rover(xMock, yMock, directionMock);

            // Act
            rover.MoveRoverWhenPointingNorth(RoverCommand.R);

            // Assert
            rover.Should().NotBeNull();
            rover.X.Should().Be(xMock);
            rover.Y.Should().Be(yMock);
            rover.Direction.Should().Be(RoverDirectionType.E);
        }

        [Fact]
        public void MoveRoverWhenPointingNorth_WhenRotatingRoverToLeft_ShouldUpdateRoverDirectionToWest()
        {
            // Arrange
            var xMock = 35;
            var yMock = 3;
            var directionMock = RoverDirectionType.N;

            var rover = new Rover(xMock, yMock, directionMock);

            // Act
            rover.MoveRoverWhenPointingNorth(RoverCommand.L);

            // Assert
            rover.Should().NotBeNull();
            rover.X.Should().Be(xMock);
            rover.Y.Should().Be(yMock);
            rover.Direction.Should().Be(RoverDirectionType.W);
        }

        [Fact]
        public void MoveRoverWhenPointingSouth_WhenMovingForwardAndCurrentRoverYValueIsNotAtGridLimit_ShouldIncreaseYValueByOne()
        {
            // Arrange
            var xMock = 3;
            var yMock = 35;
            var directionMock = RoverDirectionType.S;

            var rover = new Rover(xMock, yMock, directionMock);

            // Act
            rover.MoveRoverWhenPointingSouth(RoverCommand.F);

            // Assert 
            rover.Should().NotBeNull();
            rover.X.Should().Be(xMock);
            rover.Y.Should().Be(yMock + 1);
            rover.Direction.Should().Be(directionMock);
        }

        [Fact]
        public void MoveRoverWhenPointingSouth_WhenMovingBackwardsAndCurrentRoverYValueIsNotAtGridLimit_ShouldDecreaseYValueByOne()
        {
            // Arrange
            var xMock = 3;
            var yMock = 35;
            var directionMock = RoverDirectionType.S;

            var rover = new Rover(xMock, yMock, directionMock);

            // Act
            rover.MoveRoverWhenPointingNorth(RoverCommand.B);

            // Assert 
            rover.Should().NotBeNull();
            rover.X.Should().Be(xMock);
            rover.Y.Should().Be(yMock - 1);
            rover.Direction.Should().Be(directionMock);
        }

        [Fact]
        public void MoveRoverWhenPointingSouth_WhenMovingForwardAndCurrentRoverYValueIsAtGridLimit_ShouldSetYValueToGridBeginning()
        {
            // Arrange
            var xMock = 3;
            var yMock = PlutoSettings.GridSize;
            var directionMock = RoverDirectionType.S;

            var rover = new Rover(xMock, yMock, directionMock);

            // Act
            rover.MoveRoverWhenPointingSouth(RoverCommand.F);

            // Assert
            rover.Should().NotBeNull();
            rover.X.Should().Be(xMock);
            rover.Y.Should().Be(default);
            rover.Direction.Should().Be(directionMock);
        }

        [Fact]
        public void MoveRoverWhenPointingSouth_WhenMovingBackwardsAndCurrentRoverYValueIsAtGridBeginning_ShouldSetYValueToGridLimit()
        {
            // Arrange
            var xMock = 3;
            var yMock = default(int);
            var directionMock = RoverDirectionType.S;

            var rover = new Rover(xMock, yMock, directionMock);

            // Act
            rover.MoveRoverWhenPointingSouth(RoverCommand.B);

            // Assert
            rover.Should().NotBeNull();
            rover.X.Should().Be(xMock);
            rover.Y.Should().Be(PlutoSettings.GridSize);
            rover.Direction.Should().Be(directionMock);
        }

        [Fact]
        public void MoveRoverWhenPointingSouth_WhenRotatingRoverToRight_ShouldUpdateRoverDirectionToWest()
        {
            // Arrange
            var xMock = 35;
            var yMock = 3;
            var directionMock = RoverDirectionType.S;

            var rover = new Rover(xMock, yMock, directionMock);

            // Act
            rover.MoveRoverWhenPointingSouth(RoverCommand.R);

            // Assert
            rover.Should().NotBeNull();
            rover.X.Should().Be(xMock);
            rover.Y.Should().Be(yMock);
            rover.Direction.Should().Be(RoverDirectionType.W);
        }

        [Fact]
        public void MoveRoverWhenPointingSouth_WhenRotatingRoverToLeft_ShouldUpdateRoverDirectionToEast()
        {
            // Arrange
            var xMock = 35;
            var yMock = 3;
            var directionMock = RoverDirectionType.S;

            var rover = new Rover(xMock, yMock, directionMock);

            // Act
            rover.MoveRoverWhenPointingSouth(RoverCommand.L);

            // Assert
            rover.Should().NotBeNull();
            rover.X.Should().Be(xMock);
            rover.Y.Should().Be(yMock);
            rover.Direction.Should().Be(RoverDirectionType.E);
        }
    }
}
