using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using TicketingCRMNS.Api.DataAccess;
using TicketingCRMNS.Api.Services;

namespace TicketingCRMNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Event")]
        [Trait("Area", "DALMapper")]
        public class TestDALEventActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALEventMapper();

                        var bo = new BOEvent();

                        bo.SetProperties(1, "A", "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

                        Event response = mapper.MapBOToEF(bo);

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
                public void MapEFToBO()
                {
                        var mapper = new DALEventMapper();

                        Event entity = new Event();

                        entity.SetProperties("A", "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

                        BOEvent  response = mapper.MapEFToBO(entity);

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
                public void MapEFToBOList()
                {
                        var mapper = new DALEventMapper();

                        Event entity = new Event();

                        entity.SetProperties("A", "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

                        List<BOEvent> response = mapper.MapEFToBO(new List<Event>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>3abd9d1d938026f55791a8c68ad6c531</Hash>
</Codenesium>*/