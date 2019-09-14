using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace TwitterNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Following")]
	[Trait("Area", "ApiModel")]
	public class TestApiFollowingServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiFollowingServerModelMapper();
			var model = new ApiFollowingServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiFollowingServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.DateFollowed.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Muted.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiFollowingServerModelMapper();
			var model = new ApiFollowingServerResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiFollowingServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.DateFollowed.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Muted.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiFollowingServerModelMapper();
			var model = new ApiFollowingServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

			JsonPatchDocument<ApiFollowingServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiFollowingServerRequestModel();
			patch.ApplyTo(response);
			response.DateFollowed.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Muted.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>796c0567173e8869f59041176ddcd40b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/