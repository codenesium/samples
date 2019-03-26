using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VehicleCapabilitty")]
	[Trait("Area", "DALMapper")]
	public class TestDALVehicleCapabilittyMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALVehicleCapabilittyMapper();
			ApiVehicleCapabilittyServerRequestModel model = new ApiVehicleCapabilittyServerRequestModel();
			model.SetProperties(1);
			VehicleCapabilitty response = mapper.MapModelToEntity(1, model);

			response.VehicleCapabilityId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALVehicleCapabilittyMapper();
			VehicleCapabilitty item = new VehicleCapabilitty();
			item.SetProperties(1, 1);
			ApiVehicleCapabilittyServerResponseModel response = mapper.MapEntityToModel(item);

			response.VehicleCapabilityId.Should().Be(1);
			response.VehicleId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALVehicleCapabilittyMapper();
			VehicleCapabilitty item = new VehicleCapabilitty();
			item.SetProperties(1, 1);
			List<ApiVehicleCapabilittyServerResponseModel> response = mapper.MapEntityToModel(new List<VehicleCapabilitty>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>e9d0c3e28f568fad10f835cdd1137db1</Hash>
</Codenesium>*/