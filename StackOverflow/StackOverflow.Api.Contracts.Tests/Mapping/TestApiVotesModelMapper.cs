using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Votes")]
	[Trait("Area", "ApiModel")]
	public class TestApiVotesModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiVotesModelMapper();
			var model = new ApiVotesRequestModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1);
			ApiVotesResponseModel response = mapper.MapRequestToResponse(1, model);

			response.BountyAmount.Should().Be(1);
			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.PostId.Should().Be(1);
			response.UserId.Should().Be(1);
			response.VoteTypeId.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiVotesModelMapper();
			var model = new ApiVotesResponseModel();
			model.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1);
			ApiVotesRequestModel response = mapper.MapResponseToRequest(model);

			response.BountyAmount.Should().Be(1);
			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PostId.Should().Be(1);
			response.UserId.Should().Be(1);
			response.VoteTypeId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiVotesModelMapper();
			var model = new ApiVotesRequestModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1);

			JsonPatchDocument<ApiVotesRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiVotesRequestModel();
			patch.ApplyTo(response);
			response.BountyAmount.Should().Be(1);
			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PostId.Should().Be(1);
			response.UserId.Should().Be(1);
			response.VoteTypeId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>af1a5352338de717758a5c9a08c57f46</Hash>
</Codenesium>*/