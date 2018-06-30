using FermataFishNS.Api.Contracts;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FermataFishNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "SpaceFeature")]
        [Trait("Area", "ApiModel")]
        public class TestApiSpaceFeatureModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiSpaceFeatureModelMapper();
                        var model = new ApiSpaceFeatureRequestModel();
                        model.SetProperties("A", 1);
                        ApiSpaceFeatureResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.StudioId.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiSpaceFeatureModelMapper();
                        var model = new ApiSpaceFeatureResponseModel();
                        model.SetProperties(1, "A", 1);
                        ApiSpaceFeatureRequestModel response = mapper.MapResponseToRequest(model);

                        response.Name.Should().Be("A");
                        response.StudioId.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>de53c6dc53b55359f059ecd8f5758acc</Hash>
</Codenesium>*/