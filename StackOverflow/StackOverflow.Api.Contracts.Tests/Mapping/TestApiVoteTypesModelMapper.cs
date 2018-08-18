using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VoteTypes")]
	[Trait("Area", "ApiModel")]
	public class TestApiVoteTypesModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiVoteTypesModelMapper();
			var model = new ApiVoteTypesRequestModel();
			model.SetProperties("A");
			ApiVoteTypesResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiVoteTypesModelMapper();
			var model = new ApiVoteTypesResponseModel();
			model.SetProperties(1, "A");
			ApiVoteTypesRequestModel response = mapper.MapResponseToRequest(model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiVoteTypesModelMapper();
			var model = new ApiVoteTypesRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiVoteTypesRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiVoteTypesRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>be9baf7d0cd476b40b6f7661fab300dd</Hash>
</Codenesium>*/