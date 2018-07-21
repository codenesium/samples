using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
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

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiTenantModelMapper();
                        var model = new ApiTenantRequestModel();
                        model.SetProperties(BitConverter.GetBytes(1), "A", "A", "A", "A");

                        JsonPatchDocument<ApiTenantRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiTenantRequestModel();
                        patch.ApplyTo(response);

                        response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.ProjectIds.Should().Be("A");
                        response.TenantTags.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>e48a0e82d519b11b4ad4ac8c2b611e14</Hash>
</Codenesium>*/