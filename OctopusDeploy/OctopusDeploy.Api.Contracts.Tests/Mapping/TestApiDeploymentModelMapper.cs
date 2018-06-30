using FluentAssertions;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Deployment")]
        [Trait("Area", "ApiModel")]
        public class TestApiDeploymentModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiDeploymentModelMapper();
                        var model = new ApiDeploymentRequestModel();
                        model.SetProperties("A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", "A", "A", "A", "A", "A");
                        ApiDeploymentResponseModel response = mapper.MapRequestToResponse("A", model);

                        response.ChannelId.Should().Be("A");
                        response.Created.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.DeployedBy.Should().Be("A");
                        response.DeployedToMachineIds.Should().Be("A");
                        response.EnvironmentId.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.ProjectGroupId.Should().Be("A");
                        response.ProjectId.Should().Be("A");
                        response.ReleaseId.Should().Be("A");
                        response.TaskId.Should().Be("A");
                        response.TenantId.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiDeploymentModelMapper();
                        var model = new ApiDeploymentResponseModel();
                        model.SetProperties("A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", "A", "A", "A", "A", "A");
                        ApiDeploymentRequestModel response = mapper.MapResponseToRequest(model);

                        response.ChannelId.Should().Be("A");
                        response.Created.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.DeployedBy.Should().Be("A");
                        response.DeployedToMachineIds.Should().Be("A");
                        response.EnvironmentId.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.ProjectGroupId.Should().Be("A");
                        response.ProjectId.Should().Be("A");
                        response.ReleaseId.Should().Be("A");
                        response.TaskId.Should().Be("A");
                        response.TenantId.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>af6f50891b27bb66543c7529640d80e2</Hash>
</Codenesium>*/