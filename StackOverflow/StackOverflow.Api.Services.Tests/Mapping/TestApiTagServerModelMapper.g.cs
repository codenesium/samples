using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Tag")]
	[Trait("Area", "ApiModel")]
	public class TestApiTagServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiTagServerModelMapper();
			var model = new ApiTagServerRequestModel();
			model.SetProperties(1, 1, "A", 1);
			ApiTagServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Count.Should().Be(1);
			response.ExcerptPostId.Should().Be(1);
			response.TagName.Should().Be("A");
			response.WikiPostId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiTagServerModelMapper();
			var model = new ApiTagServerResponseModel();
			model.SetProperties(1, 1, 1, "A", 1);
			ApiTagServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Count.Should().Be(1);
			response.ExcerptPostId.Should().Be(1);
			response.TagName.Should().Be("A");
			response.WikiPostId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiTagServerModelMapper();
			var model = new ApiTagServerRequestModel();
			model.SetProperties(1, 1, "A", 1);

			JsonPatchDocument<ApiTagServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiTagServerRequestModel();
			patch.ApplyTo(response);
			response.Count.Should().Be(1);
			response.ExcerptPostId.Should().Be(1);
			response.TagName.Should().Be("A");
			response.WikiPostId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>93c8fa837817299eb3378e940619d664</Hash>
</Codenesium>*/