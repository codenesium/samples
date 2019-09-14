using FluentAssertions;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Tenant")]
	[Trait("Area", "DALMapper")]
	public class TestDALTenantMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALTenantMapper();
			ApiTenantServerRequestModel model = new ApiTenantServerRequestModel();
			model.SetProperties("A");
			Tenant response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALTenantMapper();
			Tenant item = new Tenant();
			item.SetProperties(1, "A");
			ApiTenantServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALTenantMapper();
			Tenant item = new Tenant();
			item.SetProperties(1, "A");
			List<ApiTenantServerResponseModel> response = mapper.MapEntityToModel(new List<Tenant>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>9f74a47a408cb16af993a33096d51294</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/