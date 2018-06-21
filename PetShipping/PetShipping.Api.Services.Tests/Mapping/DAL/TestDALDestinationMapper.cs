using FluentAssertions;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Destination")]
        [Trait("Area", "DALMapper")]
        public class TestDALDestinationMapper
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

                        BODestination response = mapper.MapEFToBO(entity);

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
    <Hash>71f5b559699c10dabb7a4b0a519e1850</Hash>
</Codenesium>*/