using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using Xunit;

namespace TwitterNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Retweet")]
	[Trait("Area", "ApiModel")]
	public class TestApiRetweetModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiRetweetModelMapper();
			var model = new ApiRetweetRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("0"), 1);
			ApiRetweetResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.RetwitterUserId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("0"));
			response.TweetTweetId.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiRetweetModelMapper();
			var model = new ApiRetweetResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("0"), 1);
			ApiRetweetRequestModel response = mapper.MapResponseToRequest(model);

			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.RetwitterUserId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("0"));
			response.TweetTweetId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiRetweetModelMapper();
			var model = new ApiRetweetRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("0"), 1);

			JsonPatchDocument<ApiRetweetRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiRetweetRequestModel();
			patch.ApplyTo(response);
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.RetwitterUserId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("0"));
			response.TweetTweetId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>9f9040a04c3ae03198983b0874d589ca</Hash>
</Codenesium>*/