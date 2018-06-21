using FluentAssertions;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Handler")]
        [Trait("Area", "DALMapper")]
        public class TestDALHandlerMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALHandlerMapper();
                        var bo = new BOHandler();
                        bo.SetProperties(1, 1, "A", "A", "A", "A");

                        Handler response = mapper.MapBOToEF(bo);

                        response.CountryId.Should().Be(1);
                        response.Email.Should().Be("A");
                        response.FirstName.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.LastName.Should().Be("A");
                        response.Phone.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALHandlerMapper();
                        Handler entity = new Handler();
                        entity.SetProperties(1, "A", "A", 1, "A", "A");

                        BOHandler response = mapper.MapEFToBO(entity);

                        response.CountryId.Should().Be(1);
                        response.Email.Should().Be("A");
                        response.FirstName.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.LastName.Should().Be("A");
                        response.Phone.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALHandlerMapper();
                        Handler entity = new Handler();
                        entity.SetProperties(1, "A", "A", 1, "A", "A");

                        List<BOHandler> response = mapper.MapEFToBO(new List<Handler>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>5d8d1dd5471e2335fb6beae1ea91f03f</Hash>
</Codenesium>*/