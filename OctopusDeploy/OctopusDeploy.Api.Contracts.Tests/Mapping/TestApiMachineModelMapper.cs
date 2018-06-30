using FluentAssertions;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Machine")]
        [Trait("Area", "ApiModel")]
        public class TestApiMachineModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiMachineModelMapper();
                        var model = new ApiMachineRequestModel();
                        model.SetProperties("A", "A", "A", true, "A", "A", "A", "A", "A", "A", "A", "A");
                        ApiMachineResponseModel response = mapper.MapRequestToResponse("A", model);

                        response.CommunicationStyle.Should().Be("A");
                        response.EnvironmentIds.Should().Be("A");
                        response.Fingerprint.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.IsDisabled.Should().Be(true);
                        response.JSON.Should().Be("A");
                        response.MachinePolicyId.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.RelatedDocumentIds.Should().Be("A");
                        response.Roles.Should().Be("A");
                        response.TenantIds.Should().Be("A");
                        response.TenantTags.Should().Be("A");
                        response.Thumbprint.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiMachineModelMapper();
                        var model = new ApiMachineResponseModel();
                        model.SetProperties("A", "A", "A", "A", true, "A", "A", "A", "A", "A", "A", "A", "A");
                        ApiMachineRequestModel response = mapper.MapResponseToRequest(model);

                        response.CommunicationStyle.Should().Be("A");
                        response.EnvironmentIds.Should().Be("A");
                        response.Fingerprint.Should().Be("A");
                        response.IsDisabled.Should().Be(true);
                        response.JSON.Should().Be("A");
                        response.MachinePolicyId.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.RelatedDocumentIds.Should().Be("A");
                        response.Roles.Should().Be("A");
                        response.TenantIds.Should().Be("A");
                        response.TenantTags.Should().Be("A");
                        response.Thumbprint.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>763a33b0e300f6ae2643726315171a26</Hash>
</Codenesium>*/