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

        public async Task<Rover> CreateRover(Rover rover)
        {
            rover.Id = Guid.NewGuid();

            await this.roverRepository.AddAsync(rover);

            return rover;
        }

        public async Task MoveRover(Guid id, RoverCommand command)
        {
            var rover = await this.roverRepository.GetAsync(id);

            switch (rover.Direction)
            {
                case RoverDirectionType.N:
                    rover.MoveRoverWhenPointingNorth(command);
                    break;
            }

            await this.roverRepository.UpdateAsync(id, rover);
        }
    }
}
