using FluentAssertions;
using System;
using System.Collections.Generic;
using TwitterNS.Api.DataAccess;
using TwitterNS.Api.Services;
using Xunit;

namespace TwitterNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Following")]
	[Trait("Area", "DALMapper")]
	public class TestDALFollowingMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALFollowingMapper();
			var bo = new BOFollowing();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

			Following response = mapper.MapBOToEF(bo);

			response.DateFollowed.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Muted.Should().Be("A");
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALFollowingMapper();
			Following entity = new Following();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);

			BOFollowing response = mapper.MapEFToBO(entity);

			response.DateFollowed.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Muted.Should().Be("A");
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALFollowingMapper();
			Following entity = new Following();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);

			List<BOFollowing> response = mapper.MapEFToBO(new List<Following>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>6ab6d4b454c03d732e604128d5d1ca39</Hash>
</Codenesium>*/