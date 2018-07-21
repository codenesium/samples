using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "DashboardConfiguration")]
        [Trait("Area", "ApiModel")]
        public class TestApiDashboardConfigurationModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiDashboardConfigurationModelMapper();
                        var model = new ApiDashboardConfigurationRequestModel();
                        model.SetProperties("A", "A", "A", "A", "A");
                        ApiDashboardConfigurationResponseModel response = mapper.MapRequestToResponse("A", model);

                        response.Id.Should().Be("A");
                        response.IncludedEnvironmentIds.Should().Be("A");
                        response.IncludedProjectIds.Should().Be("A");
                        response.IncludedTenantIds.Should().Be("A");
                        response.IncludedTenantTags.Should().Be("A");
                        response.JSON.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiDashboardConfigurationModelMapper();
                        var model = new ApiDashboardConfigurationResponseModel();
                        model.SetProperties("A", "A", "A", "A", "A", "A");
                        ApiDashboardConfigurationRequestModel response = mapper.MapResponseToRequest(model);

                        response.IncludedEnvironmentIds.Should().Be("A");
                        response.IncludedProjectIds.Should().Be("A");
                        response.IncludedTenantIds.Should().Be("A");
                        response.IncludedTenantTags.Should().Be("A");
                        response.JSON.Should().Be("A");
                }

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiDashboardConfigurationModelMapper();
                        var model = new ApiDashboardConfigurationRequestModel();
                        model.SetProperties("A", "A", "A", "A", "A");

                        JsonPatchDocument<ApiDashboardConfigurationRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiDashboardConfigurationRequestModel();
                        patch.ApplyTo(response);

                        response.IncludedEnvironmentIds.Should().Be("A");
                        response.IncludedProjectIds.Should().Be("A");
                        response.IncludedTenantIds.Should().Be("A");
                        response.IncludedTenantTags.Should().Be("A");
                        response.JSON.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>a1c2f8b11d832113834483a351da8ac8</Hash>
</Codenesium>*/