using FluentAssertions;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Tenant")]
        [Trait("Area", "ApiModel")]
        public class TestApiTenantModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiTenantModelMapper();
                        var model = new ApiTenantRequestModel();
                        model.SetProperties(BitConverter.GetBytes(1), "A", "A", "A", "A");
                        ApiTenantResponseModel response = mapper.MapRequestToResponse("A", model);

                        response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.ProjectIds.Should().Be("A");
                        response.TenantTags.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiTenantModelMapper();
                        var model = new ApiTenantResponseModel();
                        model.SetProperties("A", BitConverter.GetBytes(1), "A", "A", "A", "A");
                        ApiTenantRequestModel response = mapper.MapResponseToRequest(model);

                        response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.ProjectIds.Should().Be("A");
                        response.TenantTags.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>1096f78e5c59fd7bfd96a0f9b430e133</Hash>
</Codenesium>*/