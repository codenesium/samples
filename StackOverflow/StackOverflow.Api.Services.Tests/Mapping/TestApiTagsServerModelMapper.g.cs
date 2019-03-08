using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Tags")]
	[Trait("Area", "ApiModel")]
	public class TestApiTagsServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiTagsServerModelMapper();
			var model = new ApiTagsServerRequestModel();
			model.SetProperties(1, 1, "A", 1);
			ApiTagsServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Count.Should().Be(1);
			response.ExcerptPostId.Should().Be(1);
			response.TagName.Should().Be("A");
			response.WikiPostId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiTagsServerModelMapper();
			var model = new ApiTagsServerResponseModel();
			model.SetProperties(1, 1, 1, "A", 1);
			ApiTagsServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Count.Should().Be(1);
			response.ExcerptPostId.Should().Be(1);
			response.TagName.Should().Be("A");
			response.WikiPostId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiTagsServerModelMapper();
			var model = new ApiTagsServerRequestModel();
			model.SetProperties(1, 1, "A", 1);

			JsonPatchDocument<ApiTagsServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiTagsServerRequestModel();
			patch.ApplyTo(response);
			response.Count.Should().Be(1);
			response.ExcerptPostId.Should().Be(1);
			response.TagName.Should().Be("A");
			response.WikiPostId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>a5aa0c7cc4331fde48c8493a63d8b022</Hash>
</Codenesium>*/