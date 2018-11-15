using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace ESPIOTNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "DeviceAction")]
	[Trait("Area", "ApiModel")]
	public class TestApiDeviceActionServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiDeviceActionServerModelMapper();
			var model = new ApiDeviceActionServerRequestModel();
			model.SetProperties("A", 1, "A");
			ApiDeviceActionServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.@Value.Should().Be("A");
			response.DeviceId.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiDeviceActionServerModelMapper();
			var model = new ApiDeviceActionServerResponseModel();
			model.SetProperties(1, "A", 1, "A");
			ApiDeviceActionServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.@Value.Should().Be("A");
			response.DeviceId.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiDeviceActionServerModelMapper();
			var model = new ApiDeviceActionServerRequestModel();
			model.SetProperties("A", 1, "A");

			JsonPatchDocument<ApiDeviceActionServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiDeviceActionServerRequestModel();
			patch.ApplyTo(response);
			response.@Value.Should().Be("A");
			response.DeviceId.Should().Be(1);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>389afff6cdffd85fa435f730a34078d2</Hash>
</Codenesium>*/