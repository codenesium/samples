using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using Xunit;

namespace TwitterNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Like")]
	[Trait("Area", "ApiModel")]
	public class TestApiLikeModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiLikeModelMapper();
			var model = new ApiLikeRequestModel();
			model.SetProperties(1, 1);
			ApiLikeResponseModel response = mapper.MapRequestToResponse(1, model);

			response.LikeId.Should().Be(1);
			response.LikerUserId.Should().Be(1);
			response.TweetId.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiLikeModelMapper();
			var model = new ApiLikeResponseModel();
			model.SetProperties(1, 1, 1);
			ApiLikeRequestModel response = mapper.MapResponseToRequest(model);

			response.LikerUserId.Should().Be(1);
			response.TweetId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiLikeModelMapper();
			var model = new ApiLikeRequestModel();
			model.SetProperties(1, 1);

			JsonPatchDocument<ApiLikeRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiLikeRequestModel();
			patch.ApplyTo(response);
			response.LikerUserId.Should().Be(1);
			response.TweetId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>856598bf00f64efe51f175dbfc1fa65f</Hash>
</Codenesium>*/