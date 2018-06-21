using FluentAssertions;
using StackOverflowNS.Api.DataAccess;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Posts")]
        [Trait("Area", "DALMapper")]
        public class TestDALPostsMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALPostsMapper();
                        var bo = new BOPosts();
                        bo.SetProperties(1, 1, 1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, 1, 1, 1, 1, "A", "A", 1);

                        Posts response = mapper.MapBOToEF(bo);

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
                public void MapEFToBO()
                {
                        var mapper = new DALPostsMapper();
                        Posts entity = new Posts();
                        entity.SetProperties(1, 1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, 1, 1, 1, 1, "A", "A", 1);

                        BOPosts response = mapper.MapEFToBO(entity);

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
                public void MapEFToBOList()
                {
                        var mapper = new DALPostsMapper();
                        Posts entity = new Posts();
                        entity.SetProperties(1, 1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, 1, 1, 1, 1, "A", "A", 1);

                        List<BOPosts> response = mapper.MapEFToBO(new List<Posts>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>f47cd1cdeba328306a9153304be006ee</Hash>
</Codenesium>*/