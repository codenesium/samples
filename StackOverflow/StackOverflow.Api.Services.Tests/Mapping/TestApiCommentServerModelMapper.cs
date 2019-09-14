using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Comment")]
	[Trait("Area", "ApiModel")]
	public class TestApiCommentServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiCommentServerModelMapper();
			var model = new ApiCommentServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", 1);
			ApiCommentServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PostId.Should().Be(1);
			response.Score.Should().Be(1);
			response.Text.Should().Be("A");
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiCommentServerModelMapper();
			var model = new ApiCommentServerResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", 1);
			ApiCommentServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PostId.Should().Be(1);
			response.Score.Should().Be(1);
			response.Text.Should().Be("A");
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiCommentServerModelMapper();
			var model = new ApiCommentServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", 1);

			JsonPatchDocument<ApiCommentServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiCommentServerRequestModel();
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
    <Hash>5162792f8921c7b941309c9e6b8ef258</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/