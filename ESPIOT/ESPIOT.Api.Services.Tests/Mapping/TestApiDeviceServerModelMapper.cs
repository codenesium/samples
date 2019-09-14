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
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), true, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			ApiDeviceServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.DateOfLastPing.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.IsActive.Should().Be(true);
			response.Name.Should().Be("A");
			response.PublicId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiDeviceServerModelMapper();
			var model = new ApiDeviceServerResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), true, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			ApiDeviceServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.DateOfLastPing.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.IsActive.Should().Be(true);
			response.Name.Should().Be("A");
			response.PublicId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiDeviceServerModelMapper();
			var model = new ApiDeviceServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), true, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

			JsonPatchDocument<ApiDeviceServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiDeviceServerRequestModel();
			patch.ApplyTo(response);
			response.DateOfLastPing.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.IsActive.Should().Be(true);
			response.Name.Should().Be("A");
			response.PublicId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}
	}
}

/*<Codenesium>
    <Hash>1761c59b23703286277e4d34da7a0399</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/