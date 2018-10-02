using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using Xunit;

namespace TwitterNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Tweet")]
	[Trait("Area", "ApiModel")]
	public class TestApiTweetModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiTweetModelMapper();
			var model = new ApiTweetRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("0"), 1);
			ApiTweetResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.LocationId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("0"));
			response.TweetId.Should().Be(1);
			response.UserUserId.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiTweetModelMapper();
			var model = new ApiTweetResponseModel();
			model.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("0"), 1);
			ApiTweetRequestModel response = mapper.MapResponseToRequest(model);

			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.LocationId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("0"));
			response.UserUserId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiTweetModelMapper();
			var model = new ApiTweetRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("0"), 1);

			JsonPatchDocument<ApiTweetRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiTweetRequestModel();
			patch.ApplyTo(response);
			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.LocationId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("0"));
			response.UserUserId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>76a3e42414ed19f5aa4e2f56853899b8</Hash>
</Codenesium>*/