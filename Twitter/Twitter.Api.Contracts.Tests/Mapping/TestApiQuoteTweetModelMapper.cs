using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using Xunit;

namespace TwitterNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "QuoteTweet")]
	[Trait("Area", "ApiModel")]
	public class TestApiQuoteTweetModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiQuoteTweetModelMapper();
			var model = new ApiQuoteTweetRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, TimeSpan.Parse("0"));
			ApiQuoteTweetResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.QuoteTweetId.Should().Be(1);
			response.RetweeterUserId.Should().Be(1);
			response.SourceTweetId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("0"));
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiQuoteTweetModelMapper();
			var model = new ApiQuoteTweetResponseModel();
			model.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, TimeSpan.Parse("0"));
			ApiQuoteTweetRequestModel response = mapper.MapResponseToRequest(model);

			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.RetweeterUserId.Should().Be(1);
			response.SourceTweetId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("0"));
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiQuoteTweetModelMapper();
			var model = new ApiQuoteTweetRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, TimeSpan.Parse("0"));

			JsonPatchDocument<ApiQuoteTweetRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiQuoteTweetRequestModel();
			patch.ApplyTo(response);
			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.RetweeterUserId.Should().Be(1);
			response.SourceTweetId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("0"));
		}
	}
}

/*<Codenesium>
    <Hash>d9669f3ee31278433f0a38373a4f8c9f</Hash>
</Codenesium>*/