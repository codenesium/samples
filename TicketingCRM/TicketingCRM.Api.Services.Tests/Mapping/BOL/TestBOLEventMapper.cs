using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;
using TicketingCRMNS.Api.Services;

namespace TicketingCRMNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Event")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLEventActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLEventMapper();

                        ApiEventRequestModel model = new ApiEventRequestModel();

                        model.SetProperties("A", "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        BOEvent response = mapper.MapModelToBO(1, model);

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

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLEventMapper();

                        BOEvent bo = new BOEvent();

                        bo.SetProperties(1, "A", "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        ApiEventResponseModel response = mapper.MapBOToModel(bo);

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
                public void MapBOToModelList()
                {
                        var mapper = new BOLEventMapper();

                        BOEvent bo = new BOEvent();

                        bo.SetProperties(1, "A", "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        List<ApiEventResponseModel> response = mapper.MapBOToModel(new List<BOEvent>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>8d6f8dfca63853cd20e4c9dc55699a75</Hash>
</Codenesium>*/