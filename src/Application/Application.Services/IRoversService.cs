using Application.Dto;

namespace PlutoRover.Application.Services
{
    public interface IRoversService
    {
        Rover CreateRover(Rover rover);

        Rover MoveRover(RoverCommand command);
    }
}
