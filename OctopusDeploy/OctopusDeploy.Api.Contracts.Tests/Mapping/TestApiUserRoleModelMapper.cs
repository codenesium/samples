using FluentAssertions;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "UserRole")]
        [Trait("Area", "ApiModel")]
        public class TestApiUserRoleModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiUserRoleModelMapper();
                        var model = new ApiUserRoleRequestModel();
                        model.SetProperties("A", "A");
                        ApiUserRoleResponseModel response = mapper.MapRequestToResponse("A", model);

                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiUserRoleModelMapper();
                        var model = new ApiUserRoleResponseModel();
                        model.SetProperties("A", "A", "A");
                        ApiUserRoleRequestModel response = mapper.MapResponseToRequest(model);

                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>05abd0154834d7cb3eec6a836e159c19</Hash>
</Codenesium>*/