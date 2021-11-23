using PlutoRover.Application.Services;
using PlutoRover.Data.Repository;
using System.Collections.Generic;

namespace PlutoRover.Application.Services.Tests.Fakes
{
    public class RoversServiceFake : RoversService
    {
        public RoversServiceFake(IRoverRepository roverRepository)
            : base(roverRepository, new Dictionary<int, int> { { 1, 12 }, { 56, 13 }, { 36, 1 }, { 22, 100 } })
        {

        }
    }
}
