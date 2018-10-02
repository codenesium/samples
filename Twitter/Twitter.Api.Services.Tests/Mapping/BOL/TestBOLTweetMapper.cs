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
	[Trait("Table", "Tweet")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLTweetMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLTweetMapper();
			ApiTweetRequestModel model = new ApiTweetRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("0"), 1);
			BOTweet response = mapper.MapModelToBO(1, model);

			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.LocationId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("0"));
			response.UserUserId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLTweetMapper();
			BOTweet bo = new BOTweet();
			bo.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("0"), 1);
			ApiTweetResponseModel response = mapper.MapBOToModel(bo);

			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.LocationId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("0"));
			response.TweetId.Should().Be(1);
			response.UserUserId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLTweetMapper();
			BOTweet bo = new BOTweet();
			bo.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("0"), 1);
			List<ApiTweetResponseModel> response = mapper.MapBOToModel(new List<BOTweet>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>582e70181212c3fd5d569141f2372216</Hash>
</Codenesium>*/