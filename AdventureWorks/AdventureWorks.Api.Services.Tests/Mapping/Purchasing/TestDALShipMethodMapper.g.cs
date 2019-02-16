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
		public void MapModelToBO()
		{
			var mapper = new DALShipMethodMapper();
			ApiShipMethodServerRequestModel model = new ApiShipMethodServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1m);
			ShipMethod response = mapper.MapModelToBO(1, model);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.ShipBase.Should().Be(1m);
			response.ShipRate.Should().Be(1m);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new DALShipMethodMapper();
			ShipMethod item = new ShipMethod();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1m);
			ApiShipMethodServerResponseModel response = mapper.MapBOToModel(item);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.ShipBase.Should().Be(1m);
			response.ShipMethodID.Should().Be(1);
			response.ShipRate.Should().Be(1m);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new DALShipMethodMapper();
			ShipMethod item = new ShipMethod();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1m);
			List<ApiShipMethodServerResponseModel> response = mapper.MapBOToModel(new List<ShipMethod>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>50f6b69e058472b9285e64dc07dfed96</Hash>
</Codenesium>*/