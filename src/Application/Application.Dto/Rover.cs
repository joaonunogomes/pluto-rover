using System;

namespace Application.Dto
{
    public class Rover
    {
        public Guid Id { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public CardinalCompassPoint CardinalCompassPoint { get; set; }
    }
}
