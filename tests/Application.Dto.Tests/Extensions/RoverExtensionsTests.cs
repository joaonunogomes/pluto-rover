using FluentAssertions;
using PlutoRover.Application.Dto.Extensions;
using PlutoRover.Infrastructure.CrossCutting.Rover;
using Xunit;

namespace PlutoRover.Application.Dto.Tests.Extensions
{
    public class RoverExtensionsTests
    {
        [Fact]
        public void MoveRoverWhenPointingNorth_WhenMovingForwardAndCurrentRoverYValueIsNotAtEndOfGrid_ShouldIncreaseYValueByOne()
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
        public void MoveRoverWhenPointingNorth_WhenMovingBackwardsAndCurrentRoverYValueIsNotAtEndOfGrid_ShouldDecreaseYValueByOne()
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
        public void MoveRoverWhenPointingNorth_WhenMovingForwardAndCurrentRoverYValueIsAtEndOfGrid_ShouldSetYValueToGridBeginning()
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
        public void MoveRoverWhenPointingNorth_WhenMovingBackwardsAndCurrentRoverYValueIsAtGridBeginning_ShouldSetYValueToEndOfGrid()
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
        public void MoveRoverWhenPointingSouth_WhenMovingForwardAndCurrentRoverYValueIsNotAtGridBeginning_ShouldDecreaseYValueByOne()
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
            rover.Y.Should().Be(yMock - 1);
            rover.Direction.Should().Be(directionMock);
        }

        [Fact]
        public void MoveRoverWhenPointingSouth_WhenMovingBackwardsAndCurrentRoverYValueIsNotAtEndOfGrid_ShouldDecreaseYValueByOne()
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
        public void MoveRoverWhenPointingSouth_WhenMovingForwardAndCurrentRoverYValueIsAtBeginning_ShouldSetYValueToEndOfGrid()
        {
            // Arrange
            var xMock = 3;
            var yMock = default(int);
            var directionMock = RoverDirectionType.S;

            var rover = new Rover(xMock, yMock, directionMock);

            // Act
            rover.MoveRoverWhenPointingSouth(RoverCommand.F);

            // Assert
            rover.Should().NotBeNull();
            rover.X.Should().Be(xMock);
            rover.Y.Should().Be(PlutoSettings.GridSize);
            rover.Direction.Should().Be(directionMock);
        }

        [Fact]
        public void MoveRoverWhenPointingSouth_WhenMovingBackwardsAndCurrentRoverYValueIsAtEndOfGrid_ShouldSetYValueToGridBeginning()
        {
            // Arrange
            var xMock = 3;
            var yMock = PlutoSettings.GridSize;
            var directionMock = RoverDirectionType.S;

            var rover = new Rover(xMock, yMock, directionMock);

            // Act
            rover.MoveRoverWhenPointingSouth(RoverCommand.B);

            // Assert
            rover.Should().NotBeNull();
            rover.X.Should().Be(xMock);
            rover.Y.Should().Be(default);
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

        [Fact]
        public void MoveRoverWhenPointingEast_WhenMovingForwardAndCurrentRoverXValueIsNotAtEndOfGrid_ShouldIncreaseXValueByOne()
        {
            // Arrange
            var xMock = 35;
            var yMock = 3;
            var directionMock = RoverDirectionType.E;

            var rover = new Rover(xMock, yMock, directionMock);

            // Act
            rover.MoveRoverWhenPointingEast(RoverCommand.F);

            // Assert 
            rover.Should().NotBeNull();
            rover.X.Should().Be(xMock + 1);
            rover.Y.Should().Be(yMock);
            rover.Direction.Should().Be(directionMock);
        }

        [Fact]
        public void MoveRoverWhenPointingEast_WhenMovingBackwardsAndCurrentRoverXValueIsNotAtEndOfGrid_ShouldDecreaseXValueByOne()
        {
            // Arrange
            var xMock = 35;
            var yMock = 3;
            var directionMock = RoverDirectionType.E;

            var rover = new Rover(xMock, yMock, directionMock);

            // Act
            rover.MoveRoverWhenPointingEast(RoverCommand.B);

            // Assert 
            rover.Should().NotBeNull();
            rover.X.Should().Be(xMock - 1);
            rover.Y.Should().Be(yMock);
            rover.Direction.Should().Be(directionMock);
        }

        [Fact]
        public void MoveRoverWhenPointingEast_WhenMovingForwardAndCurrentRoverXValueIsAtEndOfGrid_ShouldSetXValueToGridBeginning()
        {
            // Arrange
            var xMock = PlutoSettings.GridSize;
            var yMock = 3;
            var directionMock = RoverDirectionType.E;

            var rover = new Rover(xMock, yMock, directionMock);

            // Act
            rover.MoveRoverWhenPointingEast(RoverCommand.F);

            // Assert
            rover.Should().NotBeNull();
            rover.X.Should().Be(default);
            rover.Y.Should().Be(yMock);
            rover.Direction.Should().Be(directionMock);
        }

        [Fact]
        public void MoveRoverWhenPointingEast_WhenMovingBackwardsAndCurrentRoverXValueIsAtGridBeginning_ShouldSetXValueToEndOfGrid()
        {
            // Arrange
            var xMock = default(int);
            var yMock = 3;
            var directionMock = RoverDirectionType.E;

            var rover = new Rover(xMock, yMock, directionMock);

            // Act
            rover.MoveRoverWhenPointingEast(RoverCommand.B);

            // Assert
            rover.Should().NotBeNull();
            rover.X.Should().Be(PlutoSettings.GridSize);
            rover.Y.Should().Be(yMock);
            rover.Direction.Should().Be(directionMock);
        }

        [Fact]
        public void MoveRoverWhenPointingEast_WhenRotatingRoverToRight_ShouldUpdateRoverDirectionToSouth()
        {
            // Arrange
            var xMock = 35;
            var yMock = 3;
            var directionMock = RoverDirectionType.E;

            var rover = new Rover(xMock, yMock, directionMock);

            // Act
            rover.MoveRoverWhenPointingEast(RoverCommand.R);

            // Assert
            rover.Should().NotBeNull();
            rover.X.Should().Be(xMock);
            rover.Y.Should().Be(yMock);
            rover.Direction.Should().Be(RoverDirectionType.S);
        }

        [Fact]
        public void MoveRoverWhenPointingEast_WhenRotatingRoverToLeft_ShouldUpdateRoverDirectionToNorth()
        {
            // Arrange
            var xMock = 35;
            var yMock = 3;
            var directionMock = RoverDirectionType.E;

            var rover = new Rover(xMock, yMock, directionMock);

            // Act
            rover.MoveRoverWhenPointingEast(RoverCommand.L);

            // Assert
            rover.Should().NotBeNull();
            rover.X.Should().Be(xMock);
            rover.Y.Should().Be(yMock);
            rover.Direction.Should().Be(RoverDirectionType.N);
        }

        [Fact]
        public void MoveRoverWhenPointingWest_WhenMovingForwardAndCurrentRoverXValueIsNotAtEndOfGrid_ShoulDecreaseXValueByOne()
        {
            // Arrange
            var xMock = 35;
            var yMock = 3;
            var directionMock = RoverDirectionType.W;

            var rover = new Rover(xMock, yMock, directionMock);

            // Act
            rover.MoveRoverWhenPointingWest(RoverCommand.F);

            // Assert 
            rover.Should().NotBeNull();
            rover.X.Should().Be(xMock - 1);
            rover.Y.Should().Be(yMock);
            rover.Direction.Should().Be(directionMock);
        }

        [Fact]
        public void MoveRoverWhenPointingWest_WhenMovingBackwardsAndCurrentRoverXValueIsNotAtEndOfGrid_ShouldIncreaseXValueByOne()
        {
            // Arrange
            var xMock = 35;
            var yMock = 3;
            var directionMock = RoverDirectionType.W;

            var rover = new Rover(xMock, yMock, directionMock);

            // Act
            rover.MoveRoverWhenPointingWest(RoverCommand.B);

            // Assert 
            rover.Should().NotBeNull();
            rover.X.Should().Be(xMock + 1);
            rover.Y.Should().Be(yMock);
            rover.Direction.Should().Be(directionMock);
        }

        [Fact]
        public void MoveRoverWhenPointingWest_WhenMovingForwardAndCurrentRoverXValueIsAtGridBeginning_ShouldSetXValueToEndOfGrid()
        {
            // Arrange
            var xMock = default(int);
            var yMock = 3;
            var directionMock = RoverDirectionType.W;

            var rover = new Rover(xMock, yMock, directionMock);

            // Act
            rover.MoveRoverWhenPointingWest(RoverCommand.F);

            // Assert
            rover.Should().NotBeNull();
            rover.X.Should().Be(PlutoSettings.GridSize);
            rover.Y.Should().Be(yMock);
            rover.Direction.Should().Be(directionMock);
        }

        [Fact]
        public void MoveRoverWhenPointingWest_WhenMovingBackwardsAndCurrentRoverXValueIsAtEndOfGrid_ShouldSetXValueToGridBeginning()
        {
            // Arrange
            var xMock = PlutoSettings.GridSize;
            var yMock = 3;
            var directionMock = RoverDirectionType.W;

            var rover = new Rover(xMock, yMock, directionMock);

            // Act
            rover.MoveRoverWhenPointingWest(RoverCommand.B);

            // Assert
            rover.Should().NotBeNull();
            rover.X.Should().Be(default);
            rover.Y.Should().Be(yMock);
            rover.Direction.Should().Be(directionMock);
        }

        [Fact]
        public void MoveRoverWhenPointingWest_WhenRotatingRoverToRight_ShouldUpdateRoverDirectionToNorth()
        {
            // Arrange
            var xMock = 35;
            var yMock = 3;
            var directionMock = RoverDirectionType.W;

            var rover = new Rover(xMock, yMock, directionMock);

            // Act
            rover.MoveRoverWhenPointingWest(RoverCommand.R);

            // Assert
            rover.Should().NotBeNull();
            rover.X.Should().Be(xMock);
            rover.Y.Should().Be(yMock);
            rover.Direction.Should().Be(RoverDirectionType.N);
        }

        [Fact]
        public void MoveRoverWhenPointingWest_WhenRotatingRoverToLeft_ShouldUpdateRoverDirectionToSouth()
        {
            // Arrange
            var xMock = 35;
            var yMock = 3;
            var directionMock = RoverDirectionType.W;

            var rover = new Rover(xMock, yMock, directionMock);

            // Act
            rover.MoveRoverWhenPointingWest(RoverCommand.L);

            // Assert
            rover.Should().NotBeNull();
            rover.X.Should().Be(xMock);
            rover.Y.Should().Be(yMock);
            rover.Direction.Should().Be(RoverDirectionType.S);
        }
    }
}
