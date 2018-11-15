using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ShipMethod")]
	[Trait("Area", "ApiModel")]
	public class TestApiShipMethodServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiShipMethodServerModelMapper();
			var model = new ApiShipMethodServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1m);
			ApiShipMethodServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.ShipBase.Should().Be(1m);
			response.ShipRate.Should().Be(1m);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiShipMethodServerModelMapper();
			var model = new ApiShipMethodServerResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1m);
			ApiShipMethodServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.ShipBase.Should().Be(1m);
			response.ShipRate.Should().Be(1m);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiShipMethodServerModelMapper();
			var model = new ApiShipMethodServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1m);

			JsonPatchDocument<ApiShipMethodServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiShipMethodServerRequestModel();
			patch.ApplyTo(response);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.ShipBase.Should().Be(1m);
			response.ShipRate.Should().Be(1m);
		}
	}
}

/*<Codenesium>
    <Hash>d11e3a0de8f1889259f29a23e60d108a</Hash>
</Codenesium>*/