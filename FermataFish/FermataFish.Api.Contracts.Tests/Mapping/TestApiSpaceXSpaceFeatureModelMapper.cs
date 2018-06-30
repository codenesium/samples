using FermataFishNS.Api.Contracts;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FermataFishNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "SpaceXSpaceFeature")]
        [Trait("Area", "ApiModel")]
        public class TestApiSpaceXSpaceFeatureModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiSpaceXSpaceFeatureModelMapper();
                        var model = new ApiSpaceXSpaceFeatureRequestModel();
                        model.SetProperties(1, 1);
                        ApiSpaceXSpaceFeatureResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Id.Should().Be(1);
                        response.SpaceFeatureId.Should().Be(1);
                        response.SpaceId.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiSpaceXSpaceFeatureModelMapper();
                        var model = new ApiSpaceXSpaceFeatureResponseModel();
                        model.SetProperties(1, 1, 1);
                        ApiSpaceXSpaceFeatureRequestModel response = mapper.MapResponseToRequest(model);

                        response.SpaceFeatureId.Should().Be(1);
                        response.SpaceId.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>b106785d53175b88f72df0bb9930d19a</Hash>
</Codenesium>*/