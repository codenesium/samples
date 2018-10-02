using FluentAssertions;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
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
			model.SetProperties("A");
			BOTenant response = mapper.MapModelToBO(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLTenantMapper();
			BOTenant bo = new BOTenant();
			bo.SetProperties(1, "A");
			ApiTenantResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLTenantMapper();
			BOTenant bo = new BOTenant();
			bo.SetProperties(1, "A");
			List<ApiTenantResponseModel> response = mapper.MapBOToModel(new List<BOTenant>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>00253abbcd5773cca61922687e4417e9</Hash>
</Codenesium>*/