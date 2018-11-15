using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace ESPIOTNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Device")]
	[Trait("Area", "ApiModel")]
	public class TestApiDeviceModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiDeviceModelMapper();
			var model = new ApiDeviceClientRequestModel();
			model.SetProperties("A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			ApiDeviceClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
			response.PublicId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiDeviceModelMapper();
			var model = new ApiDeviceClientResponseModel();
			model.SetProperties(1, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			ApiDeviceClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
			response.PublicId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}
	}
}

/*<Codenesium>
    <Hash>ac5bc30275896f5a7124180197a2385a</Hash>
</Codenesium>*/