using FluentAssertions;
using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;
using Xunit;

namespace TwitterNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "QuoteTweet")]
	[Trait("Area", "DALMapper")]
	public class TestDALQuoteTweetMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALQuoteTweetMapper();
			ApiQuoteTweetServerRequestModel model = new ApiQuoteTweetServerRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, TimeSpan.Parse("01:00:00"));
			QuoteTweet response = mapper.MapModelToEntity(1, model);

			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.RetweeterUserId.Should().Be(1);
			response.SourceTweetId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALQuoteTweetMapper();
			QuoteTweet item = new QuoteTweet();
			item.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, TimeSpan.Parse("01:00:00"));
			ApiQuoteTweetServerResponseModel response = mapper.MapEntityToModel(item);

			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.QuoteTweetId.Should().Be(1);
			response.RetweeterUserId.Should().Be(1);
			response.SourceTweetId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALQuoteTweetMapper();
			QuoteTweet item = new QuoteTweet();
			item.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, TimeSpan.Parse("01:00:00"));
			List<ApiQuoteTweetServerResponseModel> response = mapper.MapEntityToModel(new List<QuoteTweet>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>d7e953f5535cbcd46e49b32bd64f4837</Hash>
</Codenesium>*/