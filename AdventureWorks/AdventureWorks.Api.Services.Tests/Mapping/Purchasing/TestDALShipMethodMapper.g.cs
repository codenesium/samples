using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ShipMethod")]
	[Trait("Area", "DALMapper")]
	public class TestDALShipMethodMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALShipMethodMapper();
			ApiShipMethodServerRequestModel model = new ApiShipMethodServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1m);
			ShipMethod response = mapper.MapModelToEntity(1, model);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.ShipBase.Should().Be(1m);
			response.ShipRate.Should().Be(1m);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALShipMethodMapper();
			ShipMethod item = new ShipMethod();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1m);
			ApiShipMethodServerResponseModel response = mapper.MapEntityToModel(item);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.ShipBase.Should().Be(1m);
			response.ShipMethodID.Should().Be(1);
			response.ShipRate.Should().Be(1m);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALShipMethodMapper();
			ShipMethod item = new ShipMethod();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1m);
			List<ApiShipMethodServerResponseModel> response = mapper.MapEntityToModel(new List<ShipMethod>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>9f6b1ee8aa2cf73604d6e78383606dad</Hash>
</Codenesium>*/