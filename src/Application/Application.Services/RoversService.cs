﻿using Application.Dto;
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

            if (command == RoverCommand.F && rover.Direction == RoverDirectionType.N)
            {
                rover.X = rover.X == PlutoSettings.GridSize ? default : rover.X + 1;
            }

            await this.roverRepository.UpdateAsync(id, rover);
        }
    }
}
