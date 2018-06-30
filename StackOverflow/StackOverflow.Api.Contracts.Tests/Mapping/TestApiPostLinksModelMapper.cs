using FluentAssertions;
using StackOverflowNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "PostLinks")]
        [Trait("Area", "ApiModel")]
        public class TestApiPostLinksModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiPostLinksModelMapper();
                        var model = new ApiPostLinksRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1);
                        ApiPostLinksResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Id.Should().Be(1);
                        response.LinkTypeId.Should().Be(1);
                        response.PostId.Should().Be(1);
                        response.RelatedPostId.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiPostLinksModelMapper();
                        var model = new ApiPostLinksResponseModel();
                        model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1);
                        ApiPostLinksRequestModel response = mapper.MapResponseToRequest(model);

                        response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.LinkTypeId.Should().Be(1);
                        response.PostId.Should().Be(1);
                        response.RelatedPostId.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>4113d952af9ec1bbdb6910d78a9433e0</Hash>
</Codenesium>*/