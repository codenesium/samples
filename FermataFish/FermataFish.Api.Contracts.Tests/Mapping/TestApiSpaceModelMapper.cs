using FermataFishNS.Api.Contracts;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FermataFishNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Space")]
        [Trait("Area", "ApiModel")]
        public class TestApiSpaceModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiSpaceModelMapper();
                        var model = new ApiSpaceRequestModel();
                        model.SetProperties("A", "A", 1);
                        ApiSpaceResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Description.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.StudioId.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiSpaceModelMapper();
                        var model = new ApiSpaceResponseModel();
                        model.SetProperties(1, "A", "A", 1);
                        ApiSpaceRequestModel response = mapper.MapResponseToRequest(model);

                        response.Description.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.StudioId.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>2df569fb358f2e412b8d4e6a53a71bab</Hash>
</Codenesium>*/