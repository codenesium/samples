using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using Xunit;

namespace TwitterNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Following")]
	[Trait("Area", "ApiModel")]
	public class TestApiFollowingModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiFollowingModelMapper();
			var model = new ApiFollowingRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiFollowingResponseModel response = mapper.MapRequestToResponse("A", model);

			response.DateFollowed.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Muted.Should().Be("A");
			response.UserId.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiFollowingModelMapper();
			var model = new ApiFollowingResponseModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiFollowingRequestModel response = mapper.MapResponseToRequest(model);

			response.DateFollowed.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Muted.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiFollowingModelMapper();
			var model = new ApiFollowingRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

			JsonPatchDocument<ApiFollowingRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiFollowingRequestModel();
			patch.ApplyTo(response);
			response.DateFollowed.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Muted.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>bea97e2641e3ce57ca24f48780ad86af</Hash>
</Codenesium>*/