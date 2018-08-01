using FluentAssertions;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "DashboardConfiguration")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLDashboardConfigurationMapper
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
    <Hash>8f90080a470771d6c19c08dc69afe28f</Hash>
</Codenesium>*/