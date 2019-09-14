using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace TwitterNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "DirectTweet")]
	[Trait("Area", "ApiModel")]
	public class TestApiDirectTweetModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiDirectTweetModelMapper();
			var model = new ApiDirectTweetClientRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("01:00:00"));
			ApiDirectTweetClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.TaggedUserId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiDirectTweetModelMapper();
			var model = new ApiDirectTweetClientResponseModel();
			model.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("01:00:00"));
			ApiDirectTweetClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.TaggedUserId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
		}
	}
}

/*<Codenesium>
    <Hash>c407b24e8e2f14cdb85be832bad454c5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/