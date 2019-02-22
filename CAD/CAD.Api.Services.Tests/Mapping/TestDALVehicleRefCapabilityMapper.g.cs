using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VehicleRefCapability")]
	[Trait("Area", "DALMapper")]
	public class TestDALVehicleRefCapabilityMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALVehicleRefCapabilityMapper();
			ApiVehicleRefCapabilityServerRequestModel model = new ApiVehicleRefCapabilityServerRequestModel();
			model.SetProperties(1, 1);
			VehicleRefCapability response = mapper.MapModelToEntity(1, model);

			response.VehicleCapabilityId.Should().Be(1);
			response.VehicleId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALVehicleRefCapabilityMapper();
			VehicleRefCapability item = new VehicleRefCapability();
			item.SetProperties(1, 1, 1);
			ApiVehicleRefCapabilityServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.VehicleCapabilityId.Should().Be(1);
			response.VehicleId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALVehicleRefCapabilityMapper();
			VehicleRefCapability item = new VehicleRefCapability();
			item.SetProperties(1, 1, 1);
			List<ApiVehicleRefCapabilityServerResponseModel> response = mapper.MapEntityToModel(new List<VehicleRefCapability>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>4a725cc52e6bdc5d6b6881fcc62368f5</Hash>
</Codenesium>*/