using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PostType")]
	[Trait("Area", "ApiModel")]
	public class TestApiPostTypeServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiPostTypeServerModelMapper();
			var model = new ApiPostTypeServerRequestModel();
			model.SetProperties("A");
			ApiPostTypeServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.RwType.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiPostTypeServerModelMapper();
			var model = new ApiPostTypeServerResponseModel();
			model.SetProperties(1, "A");
			ApiPostTypeServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.RwType.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiPostTypeServerModelMapper();
			var model = new ApiPostTypeServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiPostTypeServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiPostTypeServerRequestModel();
			patch.ApplyTo(response);
			response.RwType.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>e9cb22d1dc8a1b2d19b815f75bf5f0f8</Hash>
</Codenesium>*/