using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VehicleCapabilitty")]
	[Trait("Area", "ApiModel")]
	public class TestApiVehicleCapabilittyModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiVehicleCapabilittyModelMapper();
			var model = new ApiVehicleCapabilittyClientRequestModel();
			model.SetProperties(1);
			ApiVehicleCapabilittyClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.VehicleCapabilityId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiVehicleCapabilittyModelMapper();
			var model = new ApiVehicleCapabilittyClientResponseModel();
			model.SetProperties(1, 1);
			ApiVehicleCapabilittyClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.VehicleCapabilityId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>e3b434fa3cbfe6e47f92a86ec83678f8</Hash>
</Codenesium>*/