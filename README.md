# Pluto Rover API

## Exercise description

After NASA’s New Horizon successfully flew past Pluto, they now plan to land a Pluto Rover
to further investigate the surface. You are responsible for developing an API that will allow
the Rover to move around the planet. As you won’t get a chance to fix your code once it is
onboard, you are expected to use test driven development.

To simplify navigation, the planet has been divided up into a grid. The rover's position and
location is represented by a combination of x and y coordinates and a letter representing
one of the four cardinal compass points. An example position might be 0, 0, N, which
means the rover is in the bottom left corner and facing North. Assume that the square
directly North from (x, y) is (x, y+1).

In order to control a rover, NASA sends a simple string of letters. The only commands you
can give the rover are ‘F’,’B’,’L’ and ‘R’

### Expected:

- Implement commands that move the rover forward/backward (‘F’,’B’). The rover
  may only move forward/backward by one grid point, and must maintain the same
  heading.
- Implement commands that turn the rover left/right (‘L’,’R’). These commands make
  the rover spin 90 degrees left or right respectively, without moving from its current
  spot.
- Implement wrapping from one edge of the grid to another. (Pluto is a sphere after
  all)
- Implement obstacle detection before each move to a new square. If a given
  sequence of commands encounters an obstacle, the rover moves up to the last
  possible point and reports the obstacle.

### Example:

- Let's say that the rover is located at 0,0 facing North on a 100x100 grid.
- Given the command "FFRFF" would put the rover at 2,2 facing East.

## Implementation Notes:

- The grid dimensions are configured on a static class called `PlutoSettings` that can be changed and should not have negative impact on the implementation.
- In order to keep it simple, Pluto obstacles are set on RoverService via dependency injection.
- A `IRepository` interface is provided in order to establish a contract for database access. To simplify and focus on the challenge proposed, no repository implementation was provided, so feel free to add a custom one if wanted, that should not change the Rover implementation.

## Rover orientation

The following orientation was assumed when developing this API, where the arrow next to the rover represents the direction the rover is pointing to:

![rover](https://github.com/joaonunogomes/pluto-rover/blob/4bf2870bcb791e63d3e80741c39d88558e4809b9/rover.PNG)

## Docker

A dockerfile was also provided to make it easier to run and deploy.
If needed, for local testing purposes, you can also use the docker-compose to help with docker build and docker run execution

## Project Structure

This project structure follows Domain Drive Design pattern.
The Visual Studio project is divided into several business layers, each one will serve its own responsability purpose.

## API

This API provides a way to move Pluto rover.
With this API you can:

- Create a Rover
- Get the Rover
- Move the Rover

The API specification is available on `http://localhost:9199/swagger`

![api-spec](https://github.com/joaonunogomes/pluto-rover/blob/8ca4fea12ede67de14be0ed0e962ab71dcf70097/README.md#L71)
