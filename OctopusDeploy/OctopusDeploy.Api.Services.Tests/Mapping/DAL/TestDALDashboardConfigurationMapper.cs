using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "DashboardConfiguration")]
        [Trait("Area", "DALMapper")]
        public class TestDALDashboardConfigurationActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALDashboardConfigurationMapper();

                        var bo = new BODashboardConfiguration();

                        bo.SetProperties("A", "A", "A", "A", "A", "A");

                        DashboardConfiguration response = mapper.MapBOToEF(bo);

                        response.Id.Should().Be("A");
                        response.IncludedEnvironmentIds.Should().Be("A");
                        response.IncludedProjectIds.Should().Be("A");
                        response.IncludedTenantIds.Should().Be("A");
                        response.IncludedTenantTags.Should().Be("A");
                        response.JSON.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALDashboardConfigurationMapper();

                        DashboardConfiguration entity = new DashboardConfiguration();

                        entity.SetProperties("A", "A", "A", "A", "A", "A");

                        BODashboardConfiguration  response = mapper.MapEFToBO(entity);

                        response.Id.Should().Be("A");
                        response.IncludedEnvironmentIds.Should().Be("A");
                        response.IncludedProjectIds.Should().Be("A");
                        response.IncludedTenantIds.Should().Be("A");
                        response.IncludedTenantTags.Should().Be("A");
                        response.JSON.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALDashboardConfigurationMapper();

                        DashboardConfiguration entity = new DashboardConfiguration();

                        entity.SetProperties("A", "A", "A", "A", "A", "A");

                        List<BODashboardConfiguration> response = mapper.MapEFToBO(new List<DashboardConfiguration>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>c2849fff06916a86a7f61ed4f2863e7b</Hash>
</Codenesium>*/