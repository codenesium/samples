using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace TwitterNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Retweet")]
	[Trait("Area", "ApiModel")]
	public class TestApiRetweetModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiRetweetModelMapper();
			var model = new ApiRetweetClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("01:00:00"), 1);
			ApiRetweetClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.RetwitterUserId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
			response.TweetTweetId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiRetweetModelMapper();
			var model = new ApiRetweetClientResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("01:00:00"), 1);
			ApiRetweetClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.RetwitterUserId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
			response.TweetTweetId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>d2d114a03d7516be47af9fe989ed96ba</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/