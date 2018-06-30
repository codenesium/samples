using FluentAssertions;
using NebulaNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Clasp")]
        [Trait("Area", "ApiModel")]
        public class TestApiClaspModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiClaspModelMapper();
                        var model = new ApiClaspRequestModel();
                        model.SetProperties(1, 1);
                        ApiClaspResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Id.Should().Be(1);
                        response.NextChainId.Should().Be(1);
                        response.PreviousChainId.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiClaspModelMapper();
                        var model = new ApiClaspResponseModel();
                        model.SetProperties(1, 1, 1);
                        ApiClaspRequestModel response = mapper.MapResponseToRequest(model);

                        response.NextChainId.Should().Be(1);
                        response.PreviousChainId.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>070b13bcb99b91d680b9e42b61c61633</Hash>
</Codenesium>*/