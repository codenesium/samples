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
			ApiFollowerServerRequestModel model = new ApiFollowerServerRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", "A");
			BOFollower response = mapper.MapModelToBO(1, model);

			response.Blocked.Should().Be("A");
			response.DateFollowed.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FollowedUserId.Should().Be(1);
			response.FollowingUserId.Should().Be(1);
			response.FollowRequestStatu.Should().Be("A");
			response.Muted.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLFollowerMapper();
			BOFollower bo = new BOFollower();
			bo.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", "A");
			ApiFollowerServerResponseModel response = mapper.MapBOToModel(bo);

			response.Blocked.Should().Be("A");
			response.DateFollowed.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FollowedUserId.Should().Be(1);
			response.FollowingUserId.Should().Be(1);
			response.FollowRequestStatu.Should().Be("A");
			response.Id.Should().Be(1);
			response.Muted.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLFollowerMapper();
			BOFollower bo = new BOFollower();
			bo.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", "A");
			List<ApiFollowerServerResponseModel> response = mapper.MapBOToModel(new List<BOFollower>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>8b185b8fa0ff9f3c781e133cbc931b53</Hash>
</Codenesium>*/