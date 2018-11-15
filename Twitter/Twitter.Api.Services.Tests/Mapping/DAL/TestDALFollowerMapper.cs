using FluentAssertions;
using System;
using System.Collections.Generic;
using TwitterNS.Api.DataAccess;
using TwitterNS.Api.Services;
using Xunit;

namespace TwitterNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Follower")]
	[Trait("Area", "DALMapper")]
	public class TestDALFollowerMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALFollowerMapper();
			var bo = new BOFollower();
			bo.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", "A");

			Follower response = mapper.MapBOToEF(bo);

			response.Blocked.Should().Be("A");
			response.DateFollowed.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FollowedUserId.Should().Be(1);
			response.FollowingUserId.Should().Be(1);
			response.FollowRequestStatu.Should().Be("A");
			response.Id.Should().Be(1);
			response.Muted.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALFollowerMapper();
			Follower entity = new Follower();
			entity.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", 1, "A");

			BOFollower response = mapper.MapEFToBO(entity);

			response.Blocked.Should().Be("A");
			response.DateFollowed.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FollowedUserId.Should().Be(1);
			response.FollowingUserId.Should().Be(1);
			response.FollowRequestStatu.Should().Be("A");
			response.Id.Should().Be(1);
			response.Muted.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALFollowerMapper();
			Follower entity = new Follower();
			entity.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", 1, "A");

			List<BOFollower> response = mapper.MapEFToBO(new List<Follower>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>1f191a4f0bc336288ca3109f754bfdea</Hash>
</Codenesium>*/