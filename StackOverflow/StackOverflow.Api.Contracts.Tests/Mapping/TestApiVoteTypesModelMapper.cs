using FluentAssertions;
using StackOverflowNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "VoteTypes")]
        [Trait("Area", "ApiModel")]
        public class TestApiVoteTypesModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiVoteTypesModelMapper();
                        var model = new ApiVoteTypesRequestModel();
                        model.SetProperties("A");
                        ApiVoteTypesResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiVoteTypesModelMapper();
                        var model = new ApiVoteTypesResponseModel();
                        model.SetProperties(1, "A");
                        ApiVoteTypesRequestModel response = mapper.MapResponseToRequest(model);

                        response.Name.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>dac4a953b048fc8eb43a55da24d3af48</Hash>
</Codenesium>*/