using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using Xunit;

namespace TwitterNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "DirectTweet")]
	[Trait("Area", "ApiModel")]
	public class TestApiDirectTweetModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiDirectTweetModelMapper();
			var model = new ApiDirectTweetRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("0"));
			ApiDirectTweetResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.TaggedUserId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("0"));
			response.TweetId.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiDirectTweetModelMapper();
			var model = new ApiDirectTweetResponseModel();
			model.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("0"));
			ApiDirectTweetRequestModel response = mapper.MapResponseToRequest(model);

			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.TaggedUserId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("0"));
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiDirectTweetModelMapper();
			var model = new ApiDirectTweetRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("0"));

			JsonPatchDocument<ApiDirectTweetRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiDirectTweetRequestModel();
			patch.ApplyTo(response);
			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.TaggedUserId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("0"));
		}
	}
}

/*<Codenesium>
    <Hash>f19c094f3e86ca6bfe7b5b174ecd8aeb</Hash>
</Codenesium>*/