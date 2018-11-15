using FluentAssertions;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Post")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLPostMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLPostMapper();
			ApiPostServerRequestModel model = new ApiPostServerRequestModel();
			model.SetProperties(1, 1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, 1, 1, 1, 1, "A", "A", 1);
			BOPost response = mapper.MapModelToBO(1, model);

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
		public void MapBOToModel()
		{
			var mapper = new BOLPostMapper();
			BOPost bo = new BOPost();
			bo.SetProperties(1, 1, 1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, 1, 1, 1, 1, "A", "A", 1);
			ApiPostServerResponseModel response = mapper.MapBOToModel(bo);

			response.AcceptedAnswerId.Should().Be(1);
			response.AnswerCount.Should().Be(1);
			response.Body.Should().Be("A");
			response.ClosedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.CommentCount.Should().Be(1);
			response.CommunityOwnedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FavoriteCount.Should().Be(1);
			response.Id.Should().Be(1);
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
		public void MapBOToModelList()
		{
			var mapper = new BOLPostMapper();
			BOPost bo = new BOPost();
			bo.SetProperties(1, 1, 1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, 1, 1, 1, 1, "A", "A", 1);
			List<ApiPostServerResponseModel> response = mapper.MapBOToModel(new List<BOPost>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>34c0342793ad204482fe0ce03fb60c0a</Hash>
</Codenesium>*/