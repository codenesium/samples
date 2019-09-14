using FluentAssertions;
using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;
using Xunit;

namespace TwitterNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Retweet")]
	[Trait("Area", "DALMapper")]
	public class TestDALRetweetMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALRetweetMapper();
			ApiRetweetServerRequestModel model = new ApiRetweetServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("01:00:00"), 1);
			Retweet response = mapper.MapModelToEntity(1, model);

			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.RetwitterUserId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
			response.TweetTweetId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALRetweetMapper();
			Retweet item = new Retweet();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("01:00:00"), 1);
			ApiRetweetServerResponseModel response = mapper.MapEntityToModel(item);

			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.RetwitterUserId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
			response.TweetTweetId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALRetweetMapper();
			Retweet item = new Retweet();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("01:00:00"), 1);
			List<ApiRetweetServerResponseModel> response = mapper.MapEntityToModel(new List<Retweet>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>09c84f6d48dd32235f87ef9ea6684af9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/