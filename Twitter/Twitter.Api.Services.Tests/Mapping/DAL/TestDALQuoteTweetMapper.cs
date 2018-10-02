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
			bo.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, TimeSpan.Parse("0"));

			QuoteTweet response = mapper.MapBOToEF(bo);

			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.QuoteTweetId.Should().Be(1);
			response.RetweeterUserId.Should().Be(1);
			response.SourceTweetId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("0"));
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALQuoteTweetMapper();
			QuoteTweet entity = new QuoteTweet();
			entity.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, TimeSpan.Parse("0"));

			BOQuoteTweet response = mapper.MapEFToBO(entity);

			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.QuoteTweetId.Should().Be(1);
			response.RetweeterUserId.Should().Be(1);
			response.SourceTweetId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("0"));
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALQuoteTweetMapper();
			QuoteTweet entity = new QuoteTweet();
			entity.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, TimeSpan.Parse("0"));

			List<BOQuoteTweet> response = mapper.MapEFToBO(new List<QuoteTweet>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>25ea2dd5709144048830d087e3b83d60</Hash>
</Codenesium>*/