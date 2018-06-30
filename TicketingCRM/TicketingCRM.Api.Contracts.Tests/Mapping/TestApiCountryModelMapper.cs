using FluentAssertions;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using Xunit;

namespace TicketingCRMNS.Api.Contracts.Tests
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
    <Hash>912d88e11e3a0b23ca0f49f401099ded</Hash>
</Codenesium>*/