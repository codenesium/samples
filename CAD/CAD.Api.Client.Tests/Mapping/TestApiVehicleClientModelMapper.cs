using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Vehicle")]
	[Trait("Area", "ApiModel")]
	public class TestApiVehicleModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiVehicleModelMapper();
			var model = new ApiVehicleClientRequestModel();
			model.SetProperties("A");
			ApiVehicleClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiVehicleModelMapper();
			var model = new ApiVehicleClientResponseModel();
			model.SetProperties(1, "A");
			ApiVehicleClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>66d47eab19e5e6f2d70bec91cf06a006</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/