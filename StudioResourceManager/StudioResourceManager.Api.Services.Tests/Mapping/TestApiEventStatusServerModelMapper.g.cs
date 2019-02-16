using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "EventStatus")]
	[Trait("Area", "ApiModel")]
	public class TestApiEventStatusServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiEventStatusServerModelMapper();
			var model = new ApiEventStatusServerRequestModel();
			model.SetProperties("A");
			ApiEventStatusServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiEventStatusServerModelMapper();
			var model = new ApiEventStatusServerResponseModel();
			model.SetProperties(1, "A");
			ApiEventStatusServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiEventStatusServerModelMapper();
			var model = new ApiEventStatusServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiEventStatusServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiEventStatusServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>d8d5b01871e4c3c820bd9fe6d18fd500</Hash>
</Codenesium>*/