using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Vehicle")]
	[Trait("Area", "DALMapper")]
	public class TestDALVehicleMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALVehicleMapper();
			ApiVehicleServerRequestModel model = new ApiVehicleServerRequestModel();
			model.SetProperties("A");
			Vehicle response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALVehicleMapper();
			Vehicle item = new Vehicle();
			item.SetProperties(1, "A");
			ApiVehicleServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALVehicleMapper();
			Vehicle item = new Vehicle();
			item.SetProperties(1, "A");
			List<ApiVehicleServerResponseModel> response = mapper.MapEntityToModel(new List<Vehicle>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>a961ff978eca76958901a8f94b5fec5e</Hash>
</Codenesium>*/