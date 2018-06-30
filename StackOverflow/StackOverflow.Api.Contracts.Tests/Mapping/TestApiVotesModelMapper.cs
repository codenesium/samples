using FluentAssertions;
using StackOverflowNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Votes")]
        [Trait("Area", "ApiModel")]
        public class TestApiVotesModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiVotesModelMapper();
                        var model = new ApiVotesRequestModel();
                        model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1);
                        ApiVotesResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.BountyAmount.Should().Be(1);
                        response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Id.Should().Be(1);
                        response.PostId.Should().Be(1);
                        response.UserId.Should().Be(1);
                        response.VoteTypeId.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiVotesModelMapper();
                        var model = new ApiVotesResponseModel();
                        model.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1);
                        ApiVotesRequestModel response = mapper.MapResponseToRequest(model);

                        response.BountyAmount.Should().Be(1);
                        response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.PostId.Should().Be(1);
                        response.UserId.Should().Be(1);
                        response.VoteTypeId.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>e6e97338276e93617e2b503a469e6d0e</Hash>
</Codenesium>*/