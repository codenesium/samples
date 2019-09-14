using FluentAssertions;
using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;
using Xunit;

namespace TwitterNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "DirectTweet")]
	[Trait("Area", "DALMapper")]
	public class TestDALDirectTweetMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALDirectTweetMapper();
			ApiDirectTweetServerRequestModel model = new ApiDirectTweetServerRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("01:00:00"));
			DirectTweet response = mapper.MapModelToEntity(1, model);

			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.TaggedUserId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALDirectTweetMapper();
			DirectTweet item = new DirectTweet();
			item.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("01:00:00"));
			ApiDirectTweetServerResponseModel response = mapper.MapEntityToModel(item);

			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.TaggedUserId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
			response.TweetId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALDirectTweetMapper();
			DirectTweet item = new DirectTweet();
			item.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("01:00:00"));
			List<ApiDirectTweetServerResponseModel> response = mapper.MapEntityToModel(new List<DirectTweet>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>b67f9283203ce470111418cb9102b5c2</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/