using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace TwitterNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Location")]
	[Trait("Area", "ApiModel")]
	public class TestApiLocationModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiLocationModelMapper();
			var model = new ApiLocationClientRequestModel();
			model.SetProperties(1, 1, "A");
			ApiLocationClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.GpsLat.Should().Be(1);
			response.GpsLong.Should().Be(1);
			response.LocationName.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiLocationModelMapper();
			var model = new ApiLocationClientResponseModel();
			model.SetProperties(1, 1, 1, "A");
			ApiLocationClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.GpsLat.Should().Be(1);
			response.GpsLong.Should().Be(1);
			response.LocationName.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>0b13260fcd691321aee820a5905b5601</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/