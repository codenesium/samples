using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VehicleOfficer")]
	[Trait("Area", "DALMapper")]
	public class TestDALVehicleOfficerMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALVehicleOfficerMapper();
			ApiVehicleOfficerServerRequestModel model = new ApiVehicleOfficerServerRequestModel();
			model.SetProperties(1, 1);
			VehicleOfficer response = mapper.MapModelToEntity(1, model);

			response.OfficerId.Should().Be(1);
			response.VehicleId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALVehicleOfficerMapper();
			VehicleOfficer item = new VehicleOfficer();
			item.SetProperties(1, 1, 1);
			ApiVehicleOfficerServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.OfficerId.Should().Be(1);
			response.VehicleId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALVehicleOfficerMapper();
			VehicleOfficer item = new VehicleOfficer();
			item.SetProperties(1, 1, 1);
			List<ApiVehicleOfficerServerResponseModel> response = mapper.MapEntityToModel(new List<VehicleOfficer>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>ca83d3cc5fbc23dd9b6d3e85246cb557</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/