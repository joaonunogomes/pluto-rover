using Application.Dto;
using Data.Repository;
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

        public void MoveRover(Guid id, RoverCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
