using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VehicleCapabilities")]
	[Trait("Area", "ApiModel")]
	public class TestApiVehicleCapabilitiesServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiVehicleCapabilitiesServerModelMapper();
			var model = new ApiVehicleCapabilitiesServerRequestModel();
			model.SetProperties(1, 1);
			ApiVehicleCapabilitiesServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.VehicleCapabilityId.Should().Be(1);
			response.VehicleId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiVehicleCapabilitiesServerModelMapper();
			var model = new ApiVehicleCapabilitiesServerResponseModel();
			model.SetProperties(1, 1, 1);
			ApiVehicleCapabilitiesServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.VehicleCapabilityId.Should().Be(1);
			response.VehicleId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiVehicleCapabilitiesServerModelMapper();
			var model = new ApiVehicleCapabilitiesServerRequestModel();
			model.SetProperties(1, 1);

			JsonPatchDocument<ApiVehicleCapabilitiesServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiVehicleCapabilitiesServerRequestModel();
			patch.ApplyTo(response);
			response.VehicleCapabilityId.Should().Be(1);
			response.VehicleId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>5e5c40d8be19b53c25b4439fb4a7e3fe</Hash>
</Codenesium>*/