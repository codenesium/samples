using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VehicleRefCapability")]
	[Trait("Area", "ApiModel")]
	public class TestApiVehicleRefCapabilityModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiVehicleRefCapabilityModelMapper();
			var model = new ApiVehicleRefCapabilityClientRequestModel();
			model.SetProperties(1, 1);
			ApiVehicleRefCapabilityClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.VehicleCapabilityId.Should().Be(1);
			response.VehicleId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiVehicleRefCapabilityModelMapper();
			var model = new ApiVehicleRefCapabilityClientResponseModel();
			model.SetProperties(1, 1, 1);
			ApiVehicleRefCapabilityClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.VehicleCapabilityId.Should().Be(1);
			response.VehicleId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>edb9a70044f9d86073e0752e76be8cc4</Hash>
</Codenesium>*/