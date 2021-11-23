using System;

namespace PlutoRover.Application.Dto
{
    public class Rover
    {
        public Rover()
        {
        }

        public Rover(int x, int y, RoverDirectionType direction)
        {
            this.X = x;
            this.Y = y;
            this.Direction = direction;
        }

        public Guid Id { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public RoverDirectionType Direction { get; set; }
    }
}
