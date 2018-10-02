using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VoteType")]
	[Trait("Area", "ApiModel")]
	public class TestApiVoteTypeModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiVoteTypeModelMapper();
			var model = new ApiVoteTypeRequestModel();
			model.SetProperties("A");
			ApiVoteTypeResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiVoteTypeModelMapper();
			var model = new ApiVoteTypeResponseModel();
			model.SetProperties(1, "A");
			ApiVoteTypeRequestModel response = mapper.MapResponseToRequest(model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiVoteTypeModelMapper();
			var model = new ApiVoteTypeRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiVoteTypeRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiVoteTypeRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>348200d531158a7506757ee1289f5b4a</Hash>
</Codenesium>*/