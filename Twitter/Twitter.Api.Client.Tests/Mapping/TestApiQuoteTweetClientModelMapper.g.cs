using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace TwitterNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "QuoteTweet")]
	[Trait("Area", "ApiModel")]
	public class TestApiQuoteTweetModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiQuoteTweetModelMapper();
			var model = new ApiQuoteTweetClientRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, TimeSpan.Parse("01:00:00"));
			ApiQuoteTweetClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.RetweeterUserId.Should().Be(1);
			response.SourceTweetId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiQuoteTweetModelMapper();
			var model = new ApiQuoteTweetClientResponseModel();
			model.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, TimeSpan.Parse("01:00:00"));
			ApiQuoteTweetClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.RetweeterUserId.Should().Be(1);
			response.SourceTweetId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
		}
	}
}

/*<Codenesium>
    <Hash>c3f71dcfd22a43ba423fd13010c1bd93</Hash>
</Codenesium>*/