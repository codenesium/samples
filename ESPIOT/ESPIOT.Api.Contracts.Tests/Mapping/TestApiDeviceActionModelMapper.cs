using ESPIOTNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace ESPIOTNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "DeviceAction")]
	[Trait("Area", "ApiModel")]
	public class TestApiDeviceActionModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiDeviceActionModelMapper();
			var model = new ApiDeviceActionRequestModel();
			model.SetProperties(1, "A", "A");
			ApiDeviceActionResponseModel response = mapper.MapRequestToResponse(1, model);

			response.DeviceId.Should().Be(1);
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.@Value.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiDeviceActionModelMapper();
			var model = new ApiDeviceActionResponseModel();
			model.SetProperties(1, 1, "A", "A");
			ApiDeviceActionRequestModel response = mapper.MapResponseToRequest(model);

			response.DeviceId.Should().Be(1);
			response.Name.Should().Be("A");
			response.@Value.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiDeviceActionModelMapper();
			var model = new ApiDeviceActionRequestModel();
			model.SetProperties(1, "A", "A");

			JsonPatchDocument<ApiDeviceActionRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiDeviceActionRequestModel();
			patch.ApplyTo(response);
			response.DeviceId.Should().Be(1);
			response.Name.Should().Be("A");
			response.@Value.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>a434cabebfc9a2466d5bcff6a050ff63</Hash>
</Codenesium>*/