using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using TicketingCRMNS.Api.DataAccess;
using TicketingCRMNS.Api.Services;

namespace TicketingCRMNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Venue")]
        [Trait("Area", "DALMapper")]
        public class TestDALVenueActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALVenueMapper();

                        var bo = new BOVenue();

                        bo.SetProperties(1, "A", "A", 1, "A", "A", "A", "A", 1, "A");

                        Venue response = mapper.MapBOToEF(bo);

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
                public void MapEFToBO()
                {
                        var mapper = new DALVenueMapper();

                        Venue entity = new Venue();

                        entity.SetProperties("A", "A", 1, "A", "A", 1, "A", "A", 1, "A");

                        BOVenue  response = mapper.MapEFToBO(entity);

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
                public void MapEFToBOList()
                {
                        var mapper = new DALVenueMapper();

                        Venue entity = new Venue();

                        entity.SetProperties("A", "A", 1, "A", "A", 1, "A", "A", 1, "A");

                        List<BOVenue> response = mapper.MapEFToBO(new List<Venue>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>b24cbc0b6c6b3229992802341f57826a</Hash>
</Codenesium>*/