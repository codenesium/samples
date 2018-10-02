using FluentAssertions;
using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;
using TwitterNS.Api.Services;
using Xunit;

namespace TwitterNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Retweet")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLRetweetMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLRetweetMapper();
			ApiRetweetRequestModel model = new ApiRetweetRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("0"), 1);
			BORetweet response = mapper.MapModelToBO(1, model);

			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.RetwitterUserId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("0"));
			response.TweetTweetId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLRetweetMapper();
			BORetweet bo = new BORetweet();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("0"), 1);
			ApiRetweetResponseModel response = mapper.MapBOToModel(bo);

			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.RetwitterUserId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("0"));
			response.TweetTweetId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLRetweetMapper();
			BORetweet bo = new BORetweet();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("0"), 1);
			List<ApiRetweetResponseModel> response = mapper.MapBOToModel(new List<BORetweet>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>77bafa48f13b7fd75e959f38081f6b81</Hash>
</Codenesium>*/