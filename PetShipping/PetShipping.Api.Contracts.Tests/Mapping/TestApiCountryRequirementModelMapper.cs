using FluentAssertions;
using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "CountryRequirement")]
        [Trait("Area", "ApiModel")]
        public class TestApiCountryRequirementModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiCountryRequirementModelMapper();
                        var model = new ApiCountryRequirementRequestModel();
                        model.SetProperties(1, "A");
                        ApiCountryRequirementResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.CountryId.Should().Be(1);
                        response.Details.Should().Be("A");
                        response.Id.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiCountryRequirementModelMapper();
                        var model = new ApiCountryRequirementResponseModel();
                        model.SetProperties(1, 1, "A");
                        ApiCountryRequirementRequestModel response = mapper.MapResponseToRequest(model);

                        response.CountryId.Should().Be(1);
                        response.Details.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>4d55445bffe7d93115993998d14e6998</Hash>
</Codenesium>*/