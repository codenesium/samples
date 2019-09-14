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
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), true, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			ApiDeviceClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.DateOfLastPing.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.IsActive.Should().Be(true);
			response.Name.Should().Be("A");
			response.PublicId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiDeviceModelMapper();
			var model = new ApiDeviceClientResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), true, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			ApiDeviceClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.DateOfLastPing.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.IsActive.Should().Be(true);
			response.Name.Should().Be("A");
			response.PublicId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}
	}
}

/*<Codenesium>
    <Hash>ae4fdceb60886ed74206e1f5a0cdebba</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/