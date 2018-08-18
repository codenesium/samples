using FluentAssertions;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Feed")]
	[Trait("Area", "DALMapper")]
	public class TestDALFeedMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALFeedMapper();
			var bo = new BOFeed();
			bo.SetProperties("A", "A", "A", "A", "A");

			Feed response = mapper.MapBOToEF(bo);

			response.FeedType.Should().Be("A");
			response.FeedUri.Should().Be("A");
			response.Id.Should().Be("A");
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALFeedMapper();
			Feed entity = new Feed();
			entity.SetProperties("A", "A", "A", "A", "A");

			BOFeed response = mapper.MapEFToBO(entity);

			response.FeedType.Should().Be("A");
			response.FeedUri.Should().Be("A");
			response.Id.Should().Be("A");
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALFeedMapper();
			Feed entity = new Feed();
			entity.SetProperties("A", "A", "A", "A", "A");

			List<BOFeed> response = mapper.MapEFToBO(new List<Feed>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>77e3d570ec02e4ccedec93ded7cf80ea</Hash>
</Codenesium>*/