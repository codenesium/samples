using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Tag")]
	[Trait("Area", "ApiModel")]
	public class TestApiTagModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiTagModelMapper();
			var model = new ApiTagClientRequestModel();
			model.SetProperties(1, 1, "A", 1);
			ApiTagClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Count.Should().Be(1);
			response.ExcerptPostId.Should().Be(1);
			response.TagName.Should().Be("A");
			response.WikiPostId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiTagModelMapper();
			var model = new ApiTagClientResponseModel();
			model.SetProperties(1, 1, 1, "A", 1);
			ApiTagClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Count.Should().Be(1);
			response.ExcerptPostId.Should().Be(1);
			response.TagName.Should().Be("A");
			response.WikiPostId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>2ed2b98ef347861c0b7340617a738da2</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/