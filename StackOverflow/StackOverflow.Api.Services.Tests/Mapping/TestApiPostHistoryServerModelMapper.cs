using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PostHistory")]
	[Trait("Area", "ApiModel")]
	public class TestApiPostHistoryServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiPostHistoryServerModelMapper();
			var model = new ApiPostHistoryServerRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", "A", "A", 1);
			ApiPostHistoryServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Comment.Should().Be("A");
			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PostHistoryTypeId.Should().Be(1);
			response.PostId.Should().Be(1);
			response.RevisionGUID.Should().Be("A");
			response.Text.Should().Be("A");
			response.UserDisplayName.Should().Be("A");
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiPostHistoryServerModelMapper();
			var model = new ApiPostHistoryServerResponseModel();
			model.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", "A", "A", 1);
			ApiPostHistoryServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Comment.Should().Be("A");
			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PostHistoryTypeId.Should().Be(1);
			response.PostId.Should().Be(1);
			response.RevisionGUID.Should().Be("A");
			response.Text.Should().Be("A");
			response.UserDisplayName.Should().Be("A");
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiPostHistoryServerModelMapper();
			var model = new ApiPostHistoryServerRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", "A", "A", 1);

			JsonPatchDocument<ApiPostHistoryServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiPostHistoryServerRequestModel();
			patch.ApplyTo(response);
			response.Comment.Should().Be("A");
			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PostHistoryTypeId.Should().Be(1);
			response.PostId.Should().Be(1);
			response.RevisionGUID.Should().Be("A");
			response.Text.Should().Be("A");
			response.UserDisplayName.Should().Be("A");
			response.UserId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>dbb376c7c53193548cb67663ef6a5814</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/