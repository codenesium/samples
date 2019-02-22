using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VehicleRefCapability")]
	[Trait("Area", "ApiModel")]
	public class TestApiVehicleRefCapabilityServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiVehicleRefCapabilityServerModelMapper();
			var model = new ApiVehicleRefCapabilityServerRequestModel();
			model.SetProperties(1, 1);
			ApiVehicleRefCapabilityServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.VehicleCapabilityId.Should().Be(1);
			response.VehicleId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiVehicleRefCapabilityServerModelMapper();
			var model = new ApiVehicleRefCapabilityServerResponseModel();
			model.SetProperties(1, 1, 1);
			ApiVehicleRefCapabilityServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.VehicleCapabilityId.Should().Be(1);
			response.VehicleId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiVehicleRefCapabilityServerModelMapper();
			var model = new ApiVehicleRefCapabilityServerRequestModel();
			model.SetProperties(1, 1);

			JsonPatchDocument<ApiVehicleRefCapabilityServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiVehicleRefCapabilityServerRequestModel();
			patch.ApplyTo(response);
			response.VehicleCapabilityId.Should().Be(1);
			response.VehicleId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>4db9477b3559bac0faa5095e0c8dd111</Hash>
</Codenesium>*/