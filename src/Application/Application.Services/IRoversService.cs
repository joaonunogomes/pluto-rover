using Application.Dto;
using System;
using System.Threading.Tasks;

namespace PlutoRover.Application.Services
{
    public interface IRoversService
    {
        Task<Rover> CreateRover(Rover rover);

        Task MoveRover(Guid id, RoverCommand command);
    }
}
