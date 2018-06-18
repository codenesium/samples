using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "DashboardConfiguration")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLDashboardConfigurationActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLDashboardConfigurationMapper();

                        ApiDashboardConfigurationRequestModel model = new ApiDashboardConfigurationRequestModel();

                        model.SetProperties("A", "A", "A", "A", "A");
                        BODashboardConfiguration response = mapper.MapModelToBO("A", model);

                        response.IncludedEnvironmentIds.Should().Be("A");
                        response.IncludedProjectIds.Should().Be("A");
                        response.IncludedTenantIds.Should().Be("A");
                        response.IncludedTenantTags.Should().Be("A");
                        response.JSON.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLDashboardConfigurationMapper();

                        BODashboardConfiguration bo = new BODashboardConfiguration();

                        bo.SetProperties("A", "A", "A", "A", "A", "A");
                        ApiDashboardConfigurationResponseModel response = mapper.MapBOToModel(bo);

                        response.Id.Should().Be("A");
                        response.IncludedEnvironmentIds.Should().Be("A");
                        response.IncludedProjectIds.Should().Be("A");
                        response.IncludedTenantIds.Should().Be("A");
                        response.IncludedTenantTags.Should().Be("A");
                        response.JSON.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLDashboardConfigurationMapper();

                        BODashboardConfiguration bo = new BODashboardConfiguration();

                        bo.SetProperties("A", "A", "A", "A", "A", "A");
                        List<ApiDashboardConfigurationResponseModel> response = mapper.MapBOToModel(new List<BODashboardConfiguration>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>5e4ecf7d9116e5d1c0f852a507c7ca06</Hash>
</Codenesium>*/