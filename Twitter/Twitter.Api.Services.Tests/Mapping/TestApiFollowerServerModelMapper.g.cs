using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace TwitterNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Follower")]
	[Trait("Area", "ApiModel")]
	public class TestApiFollowerServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiFollowerServerModelMapper();
			var model = new ApiFollowerServerRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", "A");
			ApiFollowerServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Blocked.Should().Be("A");
			response.DateFollowed.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FollowedUserId.Should().Be(1);
			response.FollowingUserId.Should().Be(1);
			response.FollowRequestStatu.Should().Be("A");
			response.Muted.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiFollowerServerModelMapper();
			var model = new ApiFollowerServerResponseModel();
			model.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", "A");
			ApiFollowerServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Blocked.Should().Be("A");
			response.DateFollowed.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FollowedUserId.Should().Be(1);
			response.FollowingUserId.Should().Be(1);
			response.FollowRequestStatu.Should().Be("A");
			response.Muted.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiFollowerServerModelMapper();
			var model = new ApiFollowerServerRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", "A");

			JsonPatchDocument<ApiFollowerServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiFollowerServerRequestModel();
			patch.ApplyTo(response);
			response.Blocked.Should().Be("A");
			response.DateFollowed.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FollowedUserId.Should().Be(1);
			response.FollowingUserId.Should().Be(1);
			response.FollowRequestStatu.Should().Be("A");
			response.Muted.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>15326443506e2871204da66b49f39124</Hash>
</Codenesium>*/