using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace ESPIOTNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "DeviceAction")]
	[Trait("Area", "ApiModel")]
	public class TestApiDeviceActionModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiDeviceActionModelMapper();
			var model = new ApiDeviceActionClientRequestModel();
			model.SetProperties("A", 1, "A");
			ApiDeviceActionClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.@Value.Should().Be("A");
			response.DeviceId.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiDeviceActionModelMapper();
			var model = new ApiDeviceActionClientResponseModel();
			model.SetProperties(1, "A", 1, "A");
			ApiDeviceActionClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.@Value.Should().Be("A");
			response.DeviceId.Should().Be(1);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>367e8f9c9b0841e410c9e9f31b6199b7</Hash>
</Codenesium>*/