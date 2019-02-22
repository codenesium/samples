using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VehicleCapability")]
	[Trait("Area", "ApiModel")]
	public class TestApiVehicleCapabilityServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiVehicleCapabilityServerModelMapper();
			var model = new ApiVehicleCapabilityServerRequestModel();
			model.SetProperties("A");
			ApiVehicleCapabilityServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiVehicleCapabilityServerModelMapper();
			var model = new ApiVehicleCapabilityServerResponseModel();
			model.SetProperties(1, "A");
			ApiVehicleCapabilityServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiVehicleCapabilityServerModelMapper();
			var model = new ApiVehicleCapabilityServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiVehicleCapabilityServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiVehicleCapabilityServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>f033acfe562243227793d726dcd9ddbe</Hash>
</Codenesium>*/