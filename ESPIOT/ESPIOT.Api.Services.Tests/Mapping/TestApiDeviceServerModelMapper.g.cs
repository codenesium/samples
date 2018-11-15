using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace ESPIOTNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Device")]
	[Trait("Area", "ApiModel")]
	public class TestApiDeviceServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiDeviceServerModelMapper();
			var model = new ApiDeviceServerRequestModel();
			model.SetProperties("A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			ApiDeviceServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
			response.PublicId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiDeviceServerModelMapper();
			var model = new ApiDeviceServerResponseModel();
			model.SetProperties(1, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			ApiDeviceServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
			response.PublicId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiDeviceServerModelMapper();
			var model = new ApiDeviceServerRequestModel();
			model.SetProperties("A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

			JsonPatchDocument<ApiDeviceServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiDeviceServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
			response.PublicId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}
	}
}

/*<Codenesium>
    <Hash>db6782365fd14f265264a2e419bb01a2</Hash>
</Codenesium>*/