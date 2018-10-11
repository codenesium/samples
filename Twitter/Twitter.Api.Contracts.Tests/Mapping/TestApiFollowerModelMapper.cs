using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using Xunit;

namespace TwitterNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Follower")]
	[Trait("Area", "ApiModel")]
	public class TestApiFollowerModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiFollowerModelMapper();
			var model = new ApiFollowerRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, 1, "A");
			ApiFollowerResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Blocked.Should().Be("A");
			response.DateFollowed.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FollowRequestStatu.Should().Be("A");
			response.FollowedUserId.Should().Be(1);
			response.FollowingUserId.Should().Be(1);
			response.Id.Should().Be(1);
			response.Muted.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiFollowerModelMapper();
			var model = new ApiFollowerResponseModel();
			model.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, 1, "A");
			ApiFollowerRequestModel response = mapper.MapResponseToRequest(model);

			response.Blocked.Should().Be("A");
			response.DateFollowed.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FollowRequestStatu.Should().Be("A");
			response.FollowedUserId.Should().Be(1);
			response.FollowingUserId.Should().Be(1);
			response.Muted.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiFollowerModelMapper();
			var model = new ApiFollowerRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, 1, "A");

			JsonPatchDocument<ApiFollowerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiFollowerRequestModel();
			patch.ApplyTo(response);
			response.Blocked.Should().Be("A");
			response.DateFollowed.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FollowRequestStatu.Should().Be("A");
			response.FollowedUserId.Should().Be(1);
			response.FollowingUserId.Should().Be(1);
			response.Muted.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>d150e06601c6d6862ba58601829cd949</Hash>
</Codenesium>*/