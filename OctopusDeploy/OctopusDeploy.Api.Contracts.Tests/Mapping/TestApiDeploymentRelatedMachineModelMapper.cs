using FluentAssertions;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "DeploymentRelatedMachine")]
        [Trait("Area", "ApiModel")]
        public class TestApiDeploymentRelatedMachineModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiDeploymentRelatedMachineModelMapper();
                        var model = new ApiDeploymentRelatedMachineRequestModel();
                        model.SetProperties("A", "A");
                        ApiDeploymentRelatedMachineResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.DeploymentId.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.MachineId.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiDeploymentRelatedMachineModelMapper();
                        var model = new ApiDeploymentRelatedMachineResponseModel();
                        model.SetProperties(1, "A", "A");
                        ApiDeploymentRelatedMachineRequestModel response = mapper.MapResponseToRequest(model);

                        response.DeploymentId.Should().Be("A");
                        response.MachineId.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>a1da009708b4721c7ac21c1848d00cf7</Hash>
</Codenesium>*/