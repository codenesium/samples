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
			ApiRetweetServerRequestModel model = new ApiRetweetServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("01:00:00"), 1);
			BORetweet response = mapper.MapModelToBO(1, model);

			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.RetwitterUserId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
			response.TweetTweetId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLRetweetMapper();
			BORetweet bo = new BORetweet();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("01:00:00"), 1);
			ApiRetweetServerResponseModel response = mapper.MapBOToModel(bo);

			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.RetwitterUserId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
			response.TweetTweetId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLRetweetMapper();
			BORetweet bo = new BORetweet();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("01:00:00"), 1);
			List<ApiRetweetServerResponseModel> response = mapper.MapBOToModel(new List<BORetweet>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>f4481faac56cc1277df5130c1de4aa4f</Hash>
</Codenesium>*/