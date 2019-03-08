using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VoteTypes")]
	[Trait("Area", "ApiModel")]
	public class TestApiVoteTypesServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiVoteTypesServerModelMapper();
			var model = new ApiVoteTypesServerRequestModel();
			model.SetProperties("A");
			ApiVoteTypesServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiVoteTypesServerModelMapper();
			var model = new ApiVoteTypesServerResponseModel();
			model.SetProperties(1, "A");
			ApiVoteTypesServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiVoteTypesServerModelMapper();
			var model = new ApiVoteTypesServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiVoteTypesServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiVoteTypesServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>45ec80287031f1f00e08ebb6e8c3925c</Hash>
</Codenesium>*/