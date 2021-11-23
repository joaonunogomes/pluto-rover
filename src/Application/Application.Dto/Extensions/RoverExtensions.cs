using Infrastructure.CrossCutting.Rover;

namespace Application.Dto.Extensions
{
    public static class RoverExtensions
    {
        public static void MoveRoverWhenPointingNorth(this Rover rover, RoverCommand command)
        {
            switch (command)
            {
                case RoverCommand.F:
                    rover.Y = rover.Y == PlutoSettings.GridSize ? default : rover.Y + 1;
                    break;
                case RoverCommand.B:
                    rover.Y = rover.Y == default ? PlutoSettings.GridSize : rover.Y - 1;
                    break;
                case RoverCommand.R:
                    rover.Direction = RoverDirectionType.E;
                    break;
                case RoverCommand.L:
                    rover.Direction = RoverDirectionType.W;
                    break;
            }
        }

        public static void MoveRoverWhenPointingSouth(this Rover rover, RoverCommand command)
        {
            switch (command)
            {
                case RoverCommand.F:
                    rover.Y = rover.Y == PlutoSettings.GridSize ? default : rover.Y + 1;
                    break;
                case RoverCommand.B:
                    rover.Y = rover.Y == default ? PlutoSettings.GridSize : rover.Y - 1;
                    break;
                case RoverCommand.R:
                    rover.Direction = RoverDirectionType.W;
                    break;
                case RoverCommand.L:
                    rover.Direction = RoverDirectionType.E;
                    break;
            }
        }
    }
}
