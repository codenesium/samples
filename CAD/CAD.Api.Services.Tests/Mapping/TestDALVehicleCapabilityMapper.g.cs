using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VehicleCapability")]
	[Trait("Area", "DALMapper")]
	public class TestDALVehicleCapabilityMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALVehicleCapabilityMapper();
			ApiVehicleCapabilityServerRequestModel model = new ApiVehicleCapabilityServerRequestModel();
			model.SetProperties("A");
			VehicleCapability response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALVehicleCapabilityMapper();
			VehicleCapability item = new VehicleCapability();
			item.SetProperties(1, "A");
			ApiVehicleCapabilityServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALVehicleCapabilityMapper();
			VehicleCapability item = new VehicleCapability();
			item.SetProperties(1, "A");
			List<ApiVehicleCapabilityServerResponseModel> response = mapper.MapEntityToModel(new List<VehicleCapability>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>3afa6a654479f94b13c5fc65d846f83d</Hash>
</Codenesium>*/