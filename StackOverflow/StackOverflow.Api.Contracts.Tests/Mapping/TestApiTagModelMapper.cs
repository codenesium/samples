using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Tag")]
	[Trait("Area", "ApiModel")]
	public class TestApiTagModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiTagModelMapper();
			var model = new ApiTagRequestModel();
			model.SetProperties(1, 1, "A", 1);
			ApiTagResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Count.Should().Be(1);
			response.ExcerptPostId.Should().Be(1);
			response.Id.Should().Be(1);
			response.TagName.Should().Be("A");
			response.WikiPostId.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiTagModelMapper();
			var model = new ApiTagResponseModel();
			model.SetProperties(1, 1, 1, "A", 1);
			ApiTagRequestModel response = mapper.MapResponseToRequest(model);

			response.Count.Should().Be(1);
			response.ExcerptPostId.Should().Be(1);
			response.TagName.Should().Be("A");
			response.WikiPostId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiTagModelMapper();
			var model = new ApiTagRequestModel();
			model.SetProperties(1, 1, "A", 1);

			JsonPatchDocument<ApiTagRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiTagRequestModel();
			patch.ApplyTo(response);
			response.Count.Should().Be(1);
			response.ExcerptPostId.Should().Be(1);
			response.TagName.Should().Be("A");
			response.WikiPostId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>cef5ee2f51b47a015e1fc0a772781bb4</Hash>
</Codenesium>*/