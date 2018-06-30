using FluentAssertions;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using Xunit;

namespace TicketingCRMNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Venue")]
        [Trait("Area", "ApiModel")]
        public class TestApiVenueModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiVenueModelMapper();
                        var model = new ApiVenueRequestModel();
                        model.SetProperties("A", "A", 1, "A", "A", "A", "A", 1, "A");
                        ApiVenueResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Address1.Should().Be("A");
                        response.Address2.Should().Be("A");
                        response.AdminId.Should().Be(1);
                        response.Email.Should().Be("A");
                        response.Facebook.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.Phone.Should().Be("A");
                        response.ProvinceId.Should().Be(1);
                        response.Website.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiVenueModelMapper();
                        var model = new ApiVenueResponseModel();
                        model.SetProperties(1, "A", "A", 1, "A", "A", "A", "A", 1, "A");
                        ApiVenueRequestModel response = mapper.MapResponseToRequest(model);

                        response.Address1.Should().Be("A");
                        response.Address2.Should().Be("A");
                        response.AdminId.Should().Be(1);
                        response.Email.Should().Be("A");
                        response.Facebook.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.Phone.Should().Be("A");
                        response.ProvinceId.Should().Be(1);
                        response.Website.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>0181056eab2d04104d632278d7339872</Hash>
</Codenesium>*/