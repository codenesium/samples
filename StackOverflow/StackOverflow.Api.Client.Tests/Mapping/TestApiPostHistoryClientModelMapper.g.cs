using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PostHistory")]
	[Trait("Area", "ApiModel")]
	public class TestApiPostHistoryModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiPostHistoryModelMapper();
			var model = new ApiPostHistoryClientRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", "A", "A", 1);
			ApiPostHistoryClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
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
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiPostHistoryModelMapper();
			var model = new ApiPostHistoryClientResponseModel();
			model.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", "A", "A", 1);
			ApiPostHistoryClientRequestModel response = mapper.MapClientResponseToRequest(model);
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
	}
}

/*<Codenesium>
    <Hash>b4a687017956d0aa6abafdcf5b01c22d</Hash>
</Codenesium>*/