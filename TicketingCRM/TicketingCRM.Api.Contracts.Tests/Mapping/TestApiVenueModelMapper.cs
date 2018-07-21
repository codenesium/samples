using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
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

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiVenueModelMapper();
                        var model = new ApiVenueRequestModel();
                        model.SetProperties("A", "A", 1, "A", "A", "A", "A", 1, "A");

                        JsonPatchDocument<ApiVenueRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiVenueRequestModel();
                        patch.ApplyTo(response);

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
    <Hash>257acb91c4b86343ebb4f660d1e6b61b</Hash>
</Codenesium>*/