using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Comments")]
	[Trait("Area", "ApiModel")]
	public class TestApiCommentsModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiCommentsModelMapper();
			var model = new ApiCommentsRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", 1);
			ApiCommentsResponseModel response = mapper.MapRequestToResponse(1, model);

			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.PostId.Should().Be(1);
			response.Score.Should().Be(1);
			response.Text.Should().Be("A");
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiCommentsModelMapper();
			var model = new ApiCommentsResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", 1);
			ApiCommentsRequestModel response = mapper.MapResponseToRequest(model);

			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PostId.Should().Be(1);
			response.Score.Should().Be(1);
			response.Text.Should().Be("A");
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiCommentsModelMapper();
			var model = new ApiCommentsRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", 1);

			JsonPatchDocument<ApiCommentsRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiCommentsRequestModel();
			patch.ApplyTo(response);
			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PostId.Should().Be(1);
			response.Score.Should().Be(1);
			response.Text.Should().Be("A");
			response.UserId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>39695b4be2f5e1b5f01f773800934520</Hash>
</Codenesium>*/