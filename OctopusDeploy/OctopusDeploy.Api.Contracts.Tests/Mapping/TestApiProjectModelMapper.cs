using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Project")]
        [Trait("Area", "ApiModel")]
        public class TestApiProjectModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiProjectModelMapper();
                        var model = new ApiProjectRequestModel();
                        model.SetProperties(true, BitConverter.GetBytes(1), "A", true, "A", true, "A", "A", "A", "A", "A", "A");
                        ApiProjectResponseModel response = mapper.MapRequestToResponse("A", model);

                        response.AutoCreateRelease.Should().Be(true);
                        response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
                        response.DeploymentProcessId.Should().Be("A");
                        response.DiscreteChannelRelease.Should().Be(true);
                        response.Id.Should().Be("A");
                        response.IncludedLibraryVariableSetIds.Should().Be("A");
                        response.IsDisabled.Should().Be(true);
                        response.JSON.Should().Be("A");
                        response.LifecycleId.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.ProjectGroupId.Should().Be("A");
                        response.Slug.Should().Be("A");
                        response.VariableSetId.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiProjectModelMapper();
                        var model = new ApiProjectResponseModel();
                        model.SetProperties("A", true, BitConverter.GetBytes(1), "A", true, "A", true, "A", "A", "A", "A", "A", "A");
                        ApiProjectRequestModel response = mapper.MapResponseToRequest(model);

                        response.AutoCreateRelease.Should().Be(true);
                        response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
                        response.DeploymentProcessId.Should().Be("A");
                        response.DiscreteChannelRelease.Should().Be(true);
                        response.IncludedLibraryVariableSetIds.Should().Be("A");
                        response.IsDisabled.Should().Be(true);
                        response.JSON.Should().Be("A");
                        response.LifecycleId.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.ProjectGroupId.Should().Be("A");
                        response.Slug.Should().Be("A");
                        response.VariableSetId.Should().Be("A");
                }

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiProjectModelMapper();
                        var model = new ApiProjectRequestModel();
                        model.SetProperties(true, BitConverter.GetBytes(1), "A", true, "A", true, "A", "A", "A", "A", "A", "A");

                        JsonPatchDocument<ApiProjectRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiProjectRequestModel();
                        patch.ApplyTo(response);

                        response.AutoCreateRelease.Should().Be(true);
                        response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
                        response.DeploymentProcessId.Should().Be("A");
                        response.DiscreteChannelRelease.Should().Be(true);
                        response.IncludedLibraryVariableSetIds.Should().Be("A");
                        response.IsDisabled.Should().Be(true);
                        response.JSON.Should().Be("A");
                        response.LifecycleId.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.ProjectGroupId.Should().Be("A");
                        response.Slug.Should().Be("A");
                        response.VariableSetId.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>2ba232973b42cf0c29c21b5a470e6072</Hash>
</Codenesium>*/