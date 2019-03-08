using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Tags")]
	[Trait("Area", "ApiModel")]
	public class TestApiTagsModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiTagsModelMapper();
			var model = new ApiTagsClientRequestModel();
			model.SetProperties(1, 1, "A", 1);
			ApiTagsClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Count.Should().Be(1);
			response.ExcerptPostId.Should().Be(1);
			response.TagName.Should().Be("A");
			response.WikiPostId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiTagsModelMapper();
			var model = new ApiTagsClientResponseModel();
			model.SetProperties(1, 1, 1, "A", 1);
			ApiTagsClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Count.Should().Be(1);
			response.ExcerptPostId.Should().Be(1);
			response.TagName.Should().Be("A");
			response.WikiPostId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>5d459a2c619c42c5a266b662714c175f</Hash>
</Codenesium>*/