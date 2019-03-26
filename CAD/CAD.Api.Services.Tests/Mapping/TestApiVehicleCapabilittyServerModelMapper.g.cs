using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VehicleCapabilitty")]
	[Trait("Area", "ApiModel")]
	public class TestApiVehicleCapabilittyServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiVehicleCapabilittyServerModelMapper();
			var model = new ApiVehicleCapabilittyServerRequestModel();
			model.SetProperties(1);
			ApiVehicleCapabilittyServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.VehicleCapabilityId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiVehicleCapabilittyServerModelMapper();
			var model = new ApiVehicleCapabilittyServerResponseModel();
			model.SetProperties(1, 1);
			ApiVehicleCapabilittyServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.VehicleCapabilityId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiVehicleCapabilittyServerModelMapper();
			var model = new ApiVehicleCapabilittyServerRequestModel();
			model.SetProperties(1);

			JsonPatchDocument<ApiVehicleCapabilittyServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiVehicleCapabilittyServerRequestModel();
			patch.ApplyTo(response);
			response.VehicleCapabilityId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>348993f376b81e2fa9968cfe0d57e0f2</Hash>
</Codenesium>*/