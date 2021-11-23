using Application.Dto;
using System;
using System.Threading.Tasks;

namespace PlutoRover.Application.Services
{
    public interface IRoversService
    {
        Task<Rover> CreateRoverAsync(Rover rover);

        Task MoveRoverAsync(Guid id, RoverCommand command);

        Task<Rover> GetRoverAsync(Guid id);
    }
}
