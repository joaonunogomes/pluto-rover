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
                    rover.X = rover.X == PlutoSettings.GridSize ? default : rover.X + 1;
                    break;
                case RoverCommand.B:
                    rover.X = rover.X == default ? PlutoSettings.GridSize : rover.X - 1;
                    break;
                case RoverCommand.R:
                    rover.Direction = RoverDirectionType.E;
                    break;
                case RoverCommand.L:
                    rover.Direction = RoverDirectionType.W;
                    break;
            }
        }
    }
}
