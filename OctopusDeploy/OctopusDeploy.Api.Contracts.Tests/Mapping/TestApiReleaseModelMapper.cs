using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Release")]
        [Trait("Area", "ApiModel")]
        public class TestApiReleaseModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiReleaseModelMapper();
                        var model = new ApiReleaseRequestModel();
                        model.SetProperties(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", "A");
                        ApiReleaseResponseModel response = mapper.MapRequestToResponse("A", model);

                        response.Assembled.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.ChannelId.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.ProjectDeploymentProcessSnapshotId.Should().Be("A");
                        response.ProjectId.Should().Be("A");
                        response.ProjectVariableSetSnapshotId.Should().Be("A");
                        response.Version.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiReleaseModelMapper();
                        var model = new ApiReleaseResponseModel();
                        model.SetProperties("A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", "A");
                        ApiReleaseRequestModel response = mapper.MapResponseToRequest(model);

                        response.Assembled.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.ChannelId.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.ProjectDeploymentProcessSnapshotId.Should().Be("A");
                        response.ProjectId.Should().Be("A");
                        response.ProjectVariableSetSnapshotId.Should().Be("A");
                        response.Version.Should().Be("A");
                }

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiReleaseModelMapper();
                        var model = new ApiReleaseRequestModel();
                        model.SetProperties(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", "A");

                        JsonPatchDocument<ApiReleaseRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiReleaseRequestModel();
                        patch.ApplyTo(response);

                        response.Assembled.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.ChannelId.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.ProjectDeploymentProcessSnapshotId.Should().Be("A");
                        response.ProjectId.Should().Be("A");
                        response.ProjectVariableSetSnapshotId.Should().Be("A");
                        response.Version.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>a677870fbb4cd2bcfa2cf2709c260f5e</Hash>
</Codenesium>*/