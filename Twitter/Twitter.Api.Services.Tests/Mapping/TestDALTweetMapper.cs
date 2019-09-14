using FluentAssertions;
using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;
using Xunit;

namespace TwitterNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Tweet")]
	[Trait("Area", "DALMapper")]
	public class TestDALTweetMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALTweetMapper();
			ApiTweetServerRequestModel model = new ApiTweetServerRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("01:00:00"), 1);
			Tweet response = mapper.MapModelToEntity(1, model);

			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.LocationId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
			response.UserUserId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALTweetMapper();
			Tweet item = new Tweet();
			item.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("01:00:00"), 1);
			ApiTweetServerResponseModel response = mapper.MapEntityToModel(item);

			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.LocationId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
			response.TweetId.Should().Be(1);
			response.UserUserId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALTweetMapper();
			Tweet item = new Tweet();
			item.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("01:00:00"), 1);
			List<ApiTweetServerResponseModel> response = mapper.MapEntityToModel(new List<Tweet>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>9f2a77a1969e2df5a982dc6af72508e1</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/