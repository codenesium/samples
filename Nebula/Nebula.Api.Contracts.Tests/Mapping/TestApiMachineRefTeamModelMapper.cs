using FluentAssertions;
using NebulaNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "MachineRefTeam")]
        [Trait("Area", "ApiModel")]
        public class TestApiMachineRefTeamModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiMachineRefTeamModelMapper();
                        var model = new ApiMachineRefTeamRequestModel();
                        model.SetProperties(1, 1);
                        ApiMachineRefTeamResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Id.Should().Be(1);
                        response.MachineId.Should().Be(1);
                        response.TeamId.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiMachineRefTeamModelMapper();
                        var model = new ApiMachineRefTeamResponseModel();
                        model.SetProperties(1, 1, 1);
                        ApiMachineRefTeamRequestModel response = mapper.MapResponseToRequest(model);

                        response.MachineId.Should().Be(1);
                        response.TeamId.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>f40201da2cf8852ccbf89551dd74e212</Hash>
</Codenesium>*/