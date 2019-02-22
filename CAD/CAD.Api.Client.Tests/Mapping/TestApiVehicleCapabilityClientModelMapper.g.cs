using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VehicleCapability")]
	[Trait("Area", "ApiModel")]
	public class TestApiVehicleCapabilityModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiVehicleCapabilityModelMapper();
			var model = new ApiVehicleCapabilityClientRequestModel();
			model.SetProperties("A");
			ApiVehicleCapabilityClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiVehicleCapabilityModelMapper();
			var model = new ApiVehicleCapabilityClientResponseModel();
			model.SetProperties(1, "A");
			ApiVehicleCapabilityClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>dcd70b314ad5c52afbae45b269515a8d</Hash>
</Codenesium>*/