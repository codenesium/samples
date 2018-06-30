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
        [Trait("Table", "Posts")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLPostsMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLPostsMapper();
                        ApiPostsRequestModel model = new ApiPostsRequestModel();
                        model.SetProperties(1, 1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, 1, 1, 1, 1, "A", "A", 1);
                        BOPosts response = mapper.MapModelToBO(1, model);

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
                        response.Tags.Should().Be("A");
                        response.Title.Should().Be("A");
                        response.ViewCount.Should().Be(1);
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLPostsMapper();
                        BOPosts bo = new BOPosts();
                        bo.SetProperties(1, 1, 1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, 1, 1, 1, 1, "A", "A", 1);
                        ApiPostsResponseModel response = mapper.MapBOToModel(bo);

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
                        response.Tags.Should().Be("A");
                        response.Title.Should().Be("A");
                        response.ViewCount.Should().Be(1);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLPostsMapper();
                        BOPosts bo = new BOPosts();
                        bo.SetProperties(1, 1, 1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, 1, 1, 1, 1, "A", "A", 1);
                        List<ApiPostsResponseModel> response = mapper.MapBOToModel(new List<BOPosts>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>35e6a2a84d4b4cf0cde6600598d68e28</Hash>
</Codenesium>*/