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
	[Trait("Table", "QuoteTweet")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLQuoteTweetMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLQuoteTweetMapper();
			ApiQuoteTweetServerRequestModel model = new ApiQuoteTweetServerRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, TimeSpan.Parse("01:00:00"));
			BOQuoteTweet response = mapper.MapModelToBO(1, model);

			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.RetweeterUserId.Should().Be(1);
			response.SourceTweetId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLQuoteTweetMapper();
			BOQuoteTweet bo = new BOQuoteTweet();
			bo.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, TimeSpan.Parse("01:00:00"));
			ApiQuoteTweetServerResponseModel response = mapper.MapBOToModel(bo);

			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.QuoteTweetId.Should().Be(1);
			response.RetweeterUserId.Should().Be(1);
			response.SourceTweetId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLQuoteTweetMapper();
			BOQuoteTweet bo = new BOQuoteTweet();
			bo.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, TimeSpan.Parse("01:00:00"));
			List<ApiQuoteTweetServerResponseModel> response = mapper.MapBOToModel(new List<BOQuoteTweet>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>3b9df16421917ac84ff411089beb38ef</Hash>
</Codenesium>*/