using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Posts")]
        [Trait("Area", "ApiModel")]
        public class TestApiPostsModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiPostsModelMapper();
                        var model = new ApiPostsRequestModel();
                        model.SetProperties(1, 1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, 1, 1, 1, 1, "A", "A", 1);
                        ApiPostsResponseModel response = mapper.MapRequestToResponse(1, model);

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
                public void MapResponseToRequest()
                {
                        var mapper = new ApiPostsModelMapper();
                        var model = new ApiPostsResponseModel();
                        model.SetProperties(1, 1, 1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, 1, 1, 1, 1, "A", "A", 1);
                        ApiPostsRequestModel response = mapper.MapResponseToRequest(model);

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
                public void CreatePatch()
                {
                        var mapper = new ApiPostsModelMapper();
                        var model = new ApiPostsRequestModel();
                        model.SetProperties(1, 1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, 1, 1, 1, 1, "A", "A", 1);

                        JsonPatchDocument<ApiPostsRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiPostsRequestModel();
                        patch.ApplyTo(response);

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
        }
}

/*<Codenesium>
    <Hash>cdede4f047a9c0892137e954dc7bd74a</Hash>
</Codenesium>*/