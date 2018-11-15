using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace TwitterNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Location")]
	[Trait("Area", "ApiModel")]
	public class TestApiLocationServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiLocationServerModelMapper();
			var model = new ApiLocationServerRequestModel();
			model.SetProperties(1, 1, "A");
			ApiLocationServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.GpsLat.Should().Be(1);
			response.GpsLong.Should().Be(1);
			response.LocationName.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiLocationServerModelMapper();
			var model = new ApiLocationServerResponseModel();
			model.SetProperties(1, 1, 1, "A");
			ApiLocationServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.GpsLat.Should().Be(1);
			response.GpsLong.Should().Be(1);
			response.LocationName.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiLocationServerModelMapper();
			var model = new ApiLocationServerRequestModel();
			model.SetProperties(1, 1, "A");

			JsonPatchDocument<ApiLocationServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiLocationServerRequestModel();
			patch.ApplyTo(response);
			response.GpsLat.Should().Be(1);
			response.GpsLong.Should().Be(1);
			response.LocationName.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>ec943bda963b96b6602895906739f087</Hash>
</Codenesium>*/