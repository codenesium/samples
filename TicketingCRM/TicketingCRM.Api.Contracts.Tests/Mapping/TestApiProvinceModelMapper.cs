using FluentAssertions;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using Xunit;

namespace TicketingCRMNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Province")]
        [Trait("Area", "ApiModel")]
        public class TestApiProvinceModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiProvinceModelMapper();
                        var model = new ApiProvinceRequestModel();
                        model.SetProperties(1, "A");
                        ApiProvinceResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.CountryId.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiProvinceModelMapper();
                        var model = new ApiProvinceResponseModel();
                        model.SetProperties(1, 1, "A");
                        ApiProvinceRequestModel response = mapper.MapResponseToRequest(model);

                        response.CountryId.Should().Be(1);
                        response.Name.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>03646046d99b27f56357fbf01c111e24</Hash>
</Codenesium>*/