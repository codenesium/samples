using FluentAssertions;
using StackOverflowNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "PostHistory")]
        [Trait("Area", "ApiModel")]
        public class TestApiPostHistoryModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiPostHistoryModelMapper();
                        var model = new ApiPostHistoryRequestModel();
                        model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", "A", "A", 1);
                        ApiPostHistoryResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Comment.Should().Be("A");
                        response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Id.Should().Be(1);
                        response.PostHistoryTypeId.Should().Be(1);
                        response.PostId.Should().Be(1);
                        response.RevisionGUID.Should().Be("A");
                        response.Text.Should().Be("A");
                        response.UserDisplayName.Should().Be("A");
                        response.UserId.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiPostHistoryModelMapper();
                        var model = new ApiPostHistoryResponseModel();
                        model.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", "A", "A", 1);
                        ApiPostHistoryRequestModel response = mapper.MapResponseToRequest(model);

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
    <Hash>2d5c70d12146d865bb5b76a47a2ccd93</Hash>
</Codenesium>*/