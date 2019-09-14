using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace TwitterNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Follower")]
	[Trait("Area", "ApiModel")]
	public class TestApiFollowerModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiFollowerModelMapper();
			var model = new ApiFollowerClientRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", "A");
			ApiFollowerClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Blocked.Should().Be("A");
			response.DateFollowed.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FollowedUserId.Should().Be(1);
			response.FollowingUserId.Should().Be(1);
			response.FollowRequestStatu.Should().Be("A");
			response.Muted.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiFollowerModelMapper();
			var model = new ApiFollowerClientResponseModel();
			model.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", "A");
			ApiFollowerClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
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
    <Hash>8fdd21f022f2eaac7ba9310a6d327979</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/