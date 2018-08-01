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
	[Trait("Table", "Tenant")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLTenantMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLTenantMapper();
			ApiTenantRequestModel model = new ApiTenantRequestModel();
			model.SetProperties(BitConverter.GetBytes(1), "A", "A", "A", "A");
			BOTenant response = mapper.MapModelToBO("A", model);

			response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
			response.ProjectIds.Should().Be("A");
			response.TenantTags.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLTenantMapper();
			BOTenant bo = new BOTenant();
			bo.SetProperties("A", BitConverter.GetBytes(1), "A", "A", "A", "A");
			ApiTenantResponseModel response = mapper.MapBOToModel(bo);

			response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.Id.Should().Be("A");
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
			response.ProjectIds.Should().Be("A");
			response.TenantTags.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLTenantMapper();
			BOTenant bo = new BOTenant();
			bo.SetProperties("A", BitConverter.GetBytes(1), "A", "A", "A", "A");
			List<ApiTenantResponseModel> response = mapper.MapBOToModel(new List<BOTenant>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>596d3bda395f1bf8bd89a44295fdfc61</Hash>
</Codenesium>*/