using FluentAssertions;
using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Country")]
        [Trait("Area", "ApiModel")]
        public class TestApiCountryModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiCountryModelMapper();
                        var model = new ApiCountryRequestModel();
                        model.SetProperties("A");
                        ApiCountryResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiCountryModelMapper();
                        var model = new ApiCountryResponseModel();
                        model.SetProperties(1, "A");
                        ApiCountryRequestModel response = mapper.MapResponseToRequest(model);

                        response.Name.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>fcc42bec496a1b2d641c12249bba04b9</Hash>
</Codenesium>*/