using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VehCapability")]
	[Trait("Area", "DALMapper")]
	public class TestDALVehCapabilityMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALVehCapabilityMapper();
			ApiVehCapabilityServerRequestModel model = new ApiVehCapabilityServerRequestModel();
			model.SetProperties("A");
			VehCapability response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALVehCapabilityMapper();
			VehCapability item = new VehCapability();
			item.SetProperties(1, "A");
			ApiVehCapabilityServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALVehCapabilityMapper();
			VehCapability item = new VehCapability();
			item.SetProperties(1, "A");
			List<ApiVehCapabilityServerResponseModel> response = mapper.MapEntityToModel(new List<VehCapability>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>a9bd887946ac636ebd45e7540dfe890a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/