using PlutoRover.Application.Dto;
using PlutoRover.Application.Dto.Extensions;
using PlutoRover.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlutoRover.Application.Services
{
    public class RoversService : IRoversService
    {
        private readonly IRoverRepository roverRepository;
        private readonly IDictionary<int, int> obstacles;

        public RoversService(IRoverRepository roverRepository, IDictionary<int, int> obstacles)
        {
            this.roverRepository = roverRepository;
            this.obstacles = obstacles;
        }

        public async Task<Rover> CreateRoverAsync(Rover rover)
        {
            rover.Id = Guid.NewGuid();

            await this.roverRepository.AddAsync(rover);

            return rover;
        }

        public async Task MoveRoverAsync(Guid id, RoverCommand command)
        {
            var rover = await this.roverRepository.GetAsync(id);

            switch (rover.Direction)
            {
                case RoverDirectionType.N:
                    rover.MoveRoverWhenPointingNorth(command);
                    break;
                case RoverDirectionType.S:
                    rover.MoveRoverWhenPointingSouth(command);
                    break;
                case RoverDirectionType.E:
                    rover.MoveRoverWhenPointingEast(command);
                    break;
                case RoverDirectionType.W:
                    rover.MoveRoverWhenPointingWest(command);
                    break;
            }

            if (obstacles.Any(o => o.Key == rover.X && o.Value == rover.Y))
            {
                throw new Exception($"Obstacle found at position ({rover.X},{rover.Y}). Can't move, please avoid this obstacle!");
            }

            await this.roverRepository.UpdateAsync(id, rover);
        }

        public Task<Rover> GetRoverAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
