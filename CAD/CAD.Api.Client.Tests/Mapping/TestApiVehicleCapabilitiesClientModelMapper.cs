using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VehicleCapabilities")]
	[Trait("Area", "ApiModel")]
	public class TestApiVehicleCapabilitiesModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiVehicleCapabilitiesModelMapper();
			var model = new ApiVehicleCapabilitiesClientRequestModel();
			model.SetProperties(1, 1);
			ApiVehicleCapabilitiesClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.VehicleCapabilityId.Should().Be(1);
			response.VehicleId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiVehicleCapabilitiesModelMapper();
			var model = new ApiVehicleCapabilitiesClientResponseModel();
			model.SetProperties(1, 1, 1);
			ApiVehicleCapabilitiesClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.VehicleCapabilityId.Should().Be(1);
			response.VehicleId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>80764b85e2ca473a18e50bb8705ae835</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/