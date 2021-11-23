using Application.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlutoRover.Application.Services;
using System;
using System.Threading.Tasks;

namespace PlutoRover.ClimbingApi.Presentation.Api.Controllers
{
    [ApiController]
    [Route("/rovers")]
    public class RoversController : ControllerBase
    {
        private readonly IRoversService roversService;
        private readonly ILogger<RoversController> logger;

        public RoversController(IRoversService roversService, ILogger<RoversController> logger)
        {
            this.roversService = roversService;
            this.logger = logger;
        }

        /// <summary>
        /// Creates a new rover
        /// </summary>
        /// <param name="rover">The rover to be created.</param>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Rover))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostAsync([FromBody] Rover rover)
        {
            try
            {
                var createdRover = await this.roversService.CreateRoverAsync(rover);

                this.logger.LogInformation($"Created rover at: {rover.X},{rover.Y},{rover.Direction}", rover);

                return this.CreatedAtAction(nameof(GetAsync), createdRover);
            }
            catch
            {
                return BadRequest("Couldn't create rover");
            }
        }

        /// <summary>
        /// Get a rover
        /// </summary>
        /// <param name="id">Universal identifier of the rover.</param>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Rover))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAsync([FromRoute] Guid id)
        {
            try
            {
                return this.Ok(await this.roversService.GetRoverAsync(id));
            }
            catch
            {
                return BadRequest("Couldn't get rover");
            }
        }

        /// <summary>
        /// Move rover
        /// </summary>
        /// <param name="id">Universal identifier of the rover.</param>
        /// <param name="command">Instruction to move the rover.</param>
        [HttpPut]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(Rover))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> MoveAsync([FromRoute] Guid id, [FromBody] RoverCommand command)
        {
            try
            {
                this.logger.LogInformation($"Moving rover: {command}");

                await this.roversService.MoveRoverAsync(id, command);
                return this.NoContent();
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message, ex);
                return BadRequest(ex.Message);
            }
        }
    }
}
