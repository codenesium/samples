using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
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
                        model.SetProperties("A", "A", "A", "A", "A", "A", "A", "A");
                        ApiTeamResponseModel response = mapper.MapRequestToResponse("A", model);

                        response.EnvironmentIds.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.MemberUserIds.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.ProjectGroupIds.Should().Be("A");
                        response.ProjectIds.Should().Be("A");
                        response.TenantIds.Should().Be("A");
                        response.TenantTags.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiTeamModelMapper();
                        var model = new ApiTeamResponseModel();
                        model.SetProperties("A", "A", "A", "A", "A", "A", "A", "A", "A");
                        ApiTeamRequestModel response = mapper.MapResponseToRequest(model);

                        response.EnvironmentIds.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.MemberUserIds.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.ProjectGroupIds.Should().Be("A");
                        response.ProjectIds.Should().Be("A");
                        response.TenantIds.Should().Be("A");
                        response.TenantTags.Should().Be("A");
                }

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiTeamModelMapper();
                        var model = new ApiTeamRequestModel();
                        model.SetProperties("A", "A", "A", "A", "A", "A", "A", "A");

                        JsonPatchDocument<ApiTeamRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiTeamRequestModel();
                        patch.ApplyTo(response);

                        response.EnvironmentIds.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.MemberUserIds.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.ProjectGroupIds.Should().Be("A");
                        response.ProjectIds.Should().Be("A");
                        response.TenantIds.Should().Be("A");
                        response.TenantTags.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>daae87d12894f440bfe2145d375744dc</Hash>
</Codenesium>*/