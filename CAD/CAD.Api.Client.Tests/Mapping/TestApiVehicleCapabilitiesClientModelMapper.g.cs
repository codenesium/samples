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
			model.SetProperties(1);
			ApiVehicleCapabilitiesClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.VehicleCapabilityId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiVehicleCapabilitiesModelMapper();
			var model = new ApiVehicleCapabilitiesClientResponseModel();
			model.SetProperties(1, 1);
			ApiVehicleCapabilitiesClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.VehicleCapabilityId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>9a571d622a17af1de7c06b39c6b13f4d</Hash>
</Codenesium>*/