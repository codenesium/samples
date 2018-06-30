using FluentAssertions;
using NebulaNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Team")]
        [Trait("Area", "ApiModel")]
        public class TestApiTeamModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiTeamModelMapper();
                        var model = new ApiTeamRequestModel();
                        model.SetProperties("A", 1);
                        ApiTeamResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.OrganizationId.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiTeamModelMapper();
                        var model = new ApiTeamResponseModel();
                        model.SetProperties(1, "A", 1);
                        ApiTeamRequestModel response = mapper.MapResponseToRequest(model);

                        response.Name.Should().Be("A");
                        response.OrganizationId.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>14e7d8e55a81259f798c0cf62994334d</Hash>
</Codenesium>*/