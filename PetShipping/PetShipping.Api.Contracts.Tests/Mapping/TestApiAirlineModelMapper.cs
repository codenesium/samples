using FluentAssertions;
using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Airline")]
        [Trait("Area", "ApiModel")]
        public class TestApiAirlineModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiAirlineModelMapper();
                        var model = new ApiAirlineRequestModel();
                        model.SetProperties("A");
                        ApiAirlineResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiAirlineModelMapper();
                        var model = new ApiAirlineResponseModel();
                        model.SetProperties(1, "A");
                        ApiAirlineRequestModel response = mapper.MapResponseToRequest(model);

                        response.Name.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>e2f889b7491ed289366910052068f9b6</Hash>
</Codenesium>*/