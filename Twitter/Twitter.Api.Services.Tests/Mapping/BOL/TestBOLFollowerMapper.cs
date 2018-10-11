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
	[Trait("Table", "Follower")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLFollowerMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLFollowerMapper();
			ApiFollowerRequestModel model = new ApiFollowerRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, 1, "A");
			BOFollower response = mapper.MapModelToBO(1, model);

			response.Blocked.Should().Be("A");
			response.DateFollowed.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FollowRequestStatu.Should().Be("A");
			response.FollowedUserId.Should().Be(1);
			response.FollowingUserId.Should().Be(1);
			response.Muted.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLFollowerMapper();
			BOFollower bo = new BOFollower();
			bo.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, 1, "A");
			ApiFollowerResponseModel response = mapper.MapBOToModel(bo);

			response.Blocked.Should().Be("A");
			response.DateFollowed.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FollowRequestStatu.Should().Be("A");
			response.FollowedUserId.Should().Be(1);
			response.FollowingUserId.Should().Be(1);
			response.Id.Should().Be(1);
			response.Muted.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLFollowerMapper();
			BOFollower bo = new BOFollower();
			bo.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, 1, "A");
			List<ApiFollowerResponseModel> response = mapper.MapBOToModel(new List<BOFollower>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>13d809fc3d3d97c1d30bcef7c3adf6e8</Hash>
</Codenesium>*/