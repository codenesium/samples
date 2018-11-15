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
	[Trait("Table", "DirectTweet")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLDirectTweetMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLDirectTweetMapper();
			ApiDirectTweetServerRequestModel model = new ApiDirectTweetServerRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("01:00:00"));
			BODirectTweet response = mapper.MapModelToBO(1, model);

			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.TaggedUserId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLDirectTweetMapper();
			BODirectTweet bo = new BODirectTweet();
			bo.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("01:00:00"));
			ApiDirectTweetServerResponseModel response = mapper.MapBOToModel(bo);

			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.TaggedUserId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
			response.TweetId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLDirectTweetMapper();
			BODirectTweet bo = new BODirectTweet();
			bo.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("01:00:00"));
			List<ApiDirectTweetServerResponseModel> response = mapper.MapBOToModel(new List<BODirectTweet>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>0fb15b274c215c4c9b79be68bf6d4ab4</Hash>
</Codenesium>*/