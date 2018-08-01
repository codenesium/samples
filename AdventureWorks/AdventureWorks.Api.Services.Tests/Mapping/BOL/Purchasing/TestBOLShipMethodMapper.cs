using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ShipMethod")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLShipMethodMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLShipMethodMapper();
			ApiShipMethodRequestModel model = new ApiShipMethodRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1m);
			BOShipMethod response = mapper.MapModelToBO(1, model);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.ShipBase.Should().Be(1m);
			response.ShipRate.Should().Be(1m);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLShipMethodMapper();
			BOShipMethod bo = new BOShipMethod();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1m);
			ApiShipMethodResponseModel response = mapper.MapBOToModel(bo);

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
			var mapper = new BOLShipMethodMapper();
			BOShipMethod bo = new BOShipMethod();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1m);
			List<ApiShipMethodResponseModel> response = mapper.MapBOToModel(new List<BOShipMethod>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>c932fb21eff8964a83af0242fdea6fa7</Hash>
</Codenesium>*/