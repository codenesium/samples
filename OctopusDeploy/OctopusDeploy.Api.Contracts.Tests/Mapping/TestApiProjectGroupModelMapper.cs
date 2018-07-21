using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ProjectGroup")]
        [Trait("Area", "ApiModel")]
        public class TestApiProjectGroupModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiProjectGroupModelMapper();
                        var model = new ApiProjectGroupRequestModel();
                        model.SetProperties(BitConverter.GetBytes(1), "A", "A");
                        ApiProjectGroupResponseModel response = mapper.MapRequestToResponse("A", model);

                        response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiProjectGroupModelMapper();
                        var model = new ApiProjectGroupResponseModel();
                        model.SetProperties("A", BitConverter.GetBytes(1), "A", "A");
                        ApiProjectGroupRequestModel response = mapper.MapResponseToRequest(model);

                        response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiProjectGroupModelMapper();
                        var model = new ApiProjectGroupRequestModel();
                        model.SetProperties(BitConverter.GetBytes(1), "A", "A");

                        JsonPatchDocument<ApiProjectGroupRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiProjectGroupRequestModel();
                        patch.ApplyTo(response);

                        response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>d1ef81867d441a39f0e06d3db42a5bbc</Hash>
</Codenesium>*/