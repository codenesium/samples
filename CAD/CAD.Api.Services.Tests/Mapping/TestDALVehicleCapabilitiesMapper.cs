using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VehicleCapabilities")]
	[Trait("Area", "DALMapper")]
	public class TestDALVehicleCapabilitiesMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALVehicleCapabilitiesMapper();
			ApiVehicleCapabilitiesServerRequestModel model = new ApiVehicleCapabilitiesServerRequestModel();
			model.SetProperties(1, 1);
			VehicleCapabilities response = mapper.MapModelToEntity(1, model);

			response.VehicleCapabilityId.Should().Be(1);
			response.VehicleId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALVehicleCapabilitiesMapper();
			VehicleCapabilities item = new VehicleCapabilities();
			item.SetProperties(1, 1, 1);
			ApiVehicleCapabilitiesServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.VehicleCapabilityId.Should().Be(1);
			response.VehicleId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALVehicleCapabilitiesMapper();
			VehicleCapabilities item = new VehicleCapabilities();
			item.SetProperties(1, 1, 1);
			List<ApiVehicleCapabilitiesServerResponseModel> response = mapper.MapEntityToModel(new List<VehicleCapabilities>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>0cc31c9a4ad0b77f539a48ff58aa9b53</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/