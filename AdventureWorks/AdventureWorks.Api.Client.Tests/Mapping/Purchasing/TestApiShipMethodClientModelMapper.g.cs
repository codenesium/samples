using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ShipMethod")]
	[Trait("Area", "ApiModel")]
	public class TestApiShipMethodModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiShipMethodModelMapper();
			var model = new ApiShipMethodClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1m);
			ApiShipMethodClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.ShipBase.Should().Be(1m);
			response.ShipRate.Should().Be(1m);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiShipMethodModelMapper();
			var model = new ApiShipMethodClientResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1m);
			ApiShipMethodClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.ShipBase.Should().Be(1m);
			response.ShipRate.Should().Be(1m);
		}
	}
}

/*<Codenesium>
    <Hash>0a8b19ece2afb18cd2004423a1f23820</Hash>
</Codenesium>*/