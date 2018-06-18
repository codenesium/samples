using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;

namespace PetShippingNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Destination")]
        [Trait("Area", "DALMapper")]
        public class TestDALDestinationActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALDestinationMapper();

                        var bo = new BODestination();

                        bo.SetProperties(1, 1, "A", 1);

                        Destination response = mapper.MapBOToEF(bo);

                        response.CountryId.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.Order.Should().Be(1);
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALDestinationMapper();

                        Destination entity = new Destination();

                        entity.SetProperties(1, 1, "A", 1);

                        BODestination  response = mapper.MapEFToBO(entity);

                        response.CountryId.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.Order.Should().Be(1);
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALDestinationMapper();

                        Destination entity = new Destination();

                        entity.SetProperties(1, 1, "A", 1);

                        List<BODestination> response = mapper.MapEFToBO(new List<Destination>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>31909d760bc152a158ca1ce41d4cf31a</Hash>
</Codenesium>*/