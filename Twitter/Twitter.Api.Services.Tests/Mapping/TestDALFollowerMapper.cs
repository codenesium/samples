using FluentAssertions;
using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;
using Xunit;

namespace TwitterNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Follower")]
	[Trait("Area", "DALMapper")]
	public class TestDALFollowerMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALFollowerMapper();
			ApiFollowerServerRequestModel model = new ApiFollowerServerRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", "A");
			Follower response = mapper.MapModelToEntity(1, model);

			response.Blocked.Should().Be("A");
			response.DateFollowed.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FollowedUserId.Should().Be(1);
			response.FollowingUserId.Should().Be(1);
			response.FollowRequestStatu.Should().Be("A");
			response.Muted.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALFollowerMapper();
			Follower item = new Follower();
			item.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", "A");
			ApiFollowerServerResponseModel response = mapper.MapEntityToModel(item);

			response.Blocked.Should().Be("A");
			response.DateFollowed.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FollowedUserId.Should().Be(1);
			response.FollowingUserId.Should().Be(1);
			response.FollowRequestStatu.Should().Be("A");
			response.Id.Should().Be(1);
			response.Muted.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALFollowerMapper();
			Follower item = new Follower();
			item.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", "A");
			List<ApiFollowerServerResponseModel> response = mapper.MapEntityToModel(new List<Follower>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>3cec1eb114566af580eba76fc2d5b637</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/