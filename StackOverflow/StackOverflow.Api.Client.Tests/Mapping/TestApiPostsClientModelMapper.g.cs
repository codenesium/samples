using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Posts")]
	[Trait("Area", "ApiModel")]
	public class TestApiPostsModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiPostsModelMapper();
			var model = new ApiPostsClientRequestModel();
			model.SetProperties(1, 1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, 1, 1, 1, 1, "A", "A", 1);
			ApiPostsClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.AcceptedAnswerId.Should().Be(1);
			response.AnswerCount.Should().Be(1);
			response.Body.Should().Be("A");
			response.ClosedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.CommentCount.Should().Be(1);
			response.CommunityOwnedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FavoriteCount.Should().Be(1);
			response.LastActivityDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.LastEditDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.LastEditorDisplayName.Should().Be("A");
			response.LastEditorUserId.Should().Be(1);
			response.OwnerUserId.Should().Be(1);
			response.ParentId.Should().Be(1);
			response.PostTypeId.Should().Be(1);
			response.Score.Should().Be(1);
			response.Tag.Should().Be("A");
			response.Title.Should().Be("A");
			response.ViewCount.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiPostsModelMapper();
			var model = new ApiPostsClientResponseModel();
			model.SetProperties(1, 1, 1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, 1, 1, 1, 1, "A", "A", 1);
			ApiPostsClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.AcceptedAnswerId.Should().Be(1);
			response.AnswerCount.Should().Be(1);
			response.Body.Should().Be("A");
			response.ClosedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.CommentCount.Should().Be(1);
			response.CommunityOwnedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FavoriteCount.Should().Be(1);
			response.LastActivityDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.LastEditDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.LastEditorDisplayName.Should().Be("A");
			response.LastEditorUserId.Should().Be(1);
			response.OwnerUserId.Should().Be(1);
			response.ParentId.Should().Be(1);
			response.PostTypeId.Should().Be(1);
			response.Score.Should().Be(1);
			response.Tag.Should().Be("A");
			response.Title.Should().Be("A");
			response.ViewCount.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>13c712cf815126f88efa7c7f415aa931</Hash>
</Codenesium>*/