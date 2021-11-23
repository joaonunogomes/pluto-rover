using Application.Dto;
using Application.Dto.Extensions;
using Data.Repository;
using Infrastructure.CrossCutting.Rover;
using System;
using System.Threading.Tasks;

namespace PlutoRover.Application.Services
{
    public class RoversService : IRoversService
    {
        private readonly IRoverRepository roverRepository;

        public RoversService(IRoverRepository roverRepository)
        {
            this.roverRepository = roverRepository;
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

            await this.roverRepository.UpdateAsync(id, rover);
        }

        public Task<Rover> GetRoverAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
