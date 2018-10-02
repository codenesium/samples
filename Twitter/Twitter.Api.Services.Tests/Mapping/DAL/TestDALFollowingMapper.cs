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
			bo.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

			Following response = mapper.MapBOToEF(bo);

			response.DateFollowed.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Muted.Should().Be("A");
			response.UserId.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALFollowingMapper();
			Following entity = new Following();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A");

			BOFollowing response = mapper.MapEFToBO(entity);

			response.DateFollowed.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Muted.Should().Be("A");
			response.UserId.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALFollowingMapper();
			Following entity = new Following();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A");

			List<BOFollowing> response = mapper.MapEFToBO(new List<Following>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>2167088afce36b5abd0b7c80177c8f2d</Hash>
</Codenesium>*/