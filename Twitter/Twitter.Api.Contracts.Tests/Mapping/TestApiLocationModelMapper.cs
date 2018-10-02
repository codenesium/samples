using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using Xunit;

namespace TwitterNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Location")]
	[Trait("Area", "ApiModel")]
	public class TestApiLocationModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiLocationModelMapper();
			var model = new ApiLocationRequestModel();
			model.SetProperties(1, 1, "A");
			ApiLocationResponseModel response = mapper.MapRequestToResponse(1, model);

			response.GpsLat.Should().Be(1);
			response.GpsLong.Should().Be(1);
			response.LocationId.Should().Be(1);
			response.LocationName.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiLocationModelMapper();
			var model = new ApiLocationResponseModel();
			model.SetProperties(1, 1, 1, "A");
			ApiLocationRequestModel response = mapper.MapResponseToRequest(model);

			response.GpsLat.Should().Be(1);
			response.GpsLong.Should().Be(1);
			response.LocationName.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiLocationModelMapper();
			var model = new ApiLocationRequestModel();
			model.SetProperties(1, 1, "A");

			JsonPatchDocument<ApiLocationRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiLocationRequestModel();
			patch.ApplyTo(response);
			response.GpsLat.Should().Be(1);
			response.GpsLong.Should().Be(1);
			response.LocationName.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>4915c9c6c990b3863ad60665da4e4421</Hash>
</Codenesium>*/