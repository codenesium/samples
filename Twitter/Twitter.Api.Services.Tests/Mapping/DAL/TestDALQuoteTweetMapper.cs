using FluentAssertions;
using System;
using System.Collections.Generic;
using TwitterNS.Api.DataAccess;
using TwitterNS.Api.Services;
using Xunit;

namespace TwitterNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "QuoteTweet")]
	[Trait("Area", "DALMapper")]
	public class TestDALQuoteTweetMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALQuoteTweetMapper();
			var bo = new BOQuoteTweet();
			bo.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, TimeSpan.Parse("01:00:00"));

			QuoteTweet response = mapper.MapBOToEF(bo);

			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.QuoteTweetId.Should().Be(1);
			response.RetweeterUserId.Should().Be(1);
			response.SourceTweetId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALQuoteTweetMapper();
			QuoteTweet entity = new QuoteTweet();
			entity.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, TimeSpan.Parse("01:00:00"));

			BOQuoteTweet response = mapper.MapEFToBO(entity);

			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.QuoteTweetId.Should().Be(1);
			response.RetweeterUserId.Should().Be(1);
			response.SourceTweetId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALQuoteTweetMapper();
			QuoteTweet entity = new QuoteTweet();
			entity.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, TimeSpan.Parse("01:00:00"));

			List<BOQuoteTweet> response = mapper.MapEFToBO(new List<QuoteTweet>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>dd476ea074037cde29e9c8e336b3a1ba</Hash>
</Codenesium>*/