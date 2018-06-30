using FluentAssertions;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using Xunit;

namespace TicketingCRMNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Event")]
        [Trait("Area", "ApiModel")]
        public class TestApiEventModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiEventModelMapper();
                        var model = new ApiEventRequestModel();
                        model.SetProperties("A", "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        ApiEventResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Address1.Should().Be("A");
                        response.Address2.Should().Be("A");
                        response.CityId.Should().Be(1);
                        response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Description.Should().Be("A");
                        response.EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Facebook.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Website.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiEventModelMapper();
                        var model = new ApiEventResponseModel();
                        model.SetProperties(1, "A", "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        ApiEventRequestModel response = mapper.MapResponseToRequest(model);

                        response.Address1.Should().Be("A");
                        response.Address2.Should().Be("A");
                        response.CityId.Should().Be(1);
                        response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Description.Should().Be("A");
                        response.EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Facebook.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Website.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>c1c74f830a4566efaf9f0975893cb7b8</Hash>
</Codenesium>*/