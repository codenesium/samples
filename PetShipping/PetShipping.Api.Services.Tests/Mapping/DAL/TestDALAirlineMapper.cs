using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;

namespace PetShippingNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Airline")]
        [Trait("Area", "DALMapper")]
        public class TestDALAirlineActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALAirlineMapper();

                        var bo = new BOAirline();

                        bo.SetProperties(1, "A");

                        Airline response = mapper.MapBOToEF(bo);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALAirlineMapper();

                        Airline entity = new Airline();

                        entity.SetProperties(1, "A");

                        BOAirline  response = mapper.MapEFToBO(entity);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALAirlineMapper();

                        Airline entity = new Airline();

                        entity.SetProperties(1, "A");

                        List<BOAirline> response = mapper.MapEFToBO(new List<Airline>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>aab216814db85f8bb303ef9c9a25cbe5</Hash>
</Codenesium>*/