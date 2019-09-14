using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VoteType")]
	[Trait("Area", "ApiModel")]
	public class TestApiVoteTypeServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiVoteTypeServerModelMapper();
			var model = new ApiVoteTypeServerRequestModel();
			model.SetProperties("A");
			ApiVoteTypeServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiVoteTypeServerModelMapper();
			var model = new ApiVoteTypeServerResponseModel();
			model.SetProperties(1, "A");
			ApiVoteTypeServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiVoteTypeServerModelMapper();
			var model = new ApiVoteTypeServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiVoteTypeServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiVoteTypeServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>4516a2c3b1034df7899fd20d06cdbf44</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/