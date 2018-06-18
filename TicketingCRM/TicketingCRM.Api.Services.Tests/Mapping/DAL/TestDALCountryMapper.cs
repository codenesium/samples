using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using TicketingCRMNS.Api.DataAccess;
using TicketingCRMNS.Api.Services;

namespace TicketingCRMNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Country")]
        [Trait("Area", "DALMapper")]
        public class TestDALCountryActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALCountryMapper();

                        var bo = new BOCountry();

                        bo.SetProperties(1, "A");

                        Country response = mapper.MapBOToEF(bo);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALCountryMapper();

                        Country entity = new Country();

                        entity.SetProperties(1, "A");

                        BOCountry  response = mapper.MapEFToBO(entity);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALCountryMapper();

                        Country entity = new Country();

                        entity.SetProperties(1, "A");

                        List<BOCountry> response = mapper.MapEFToBO(new List<Country>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>f392efcf59792ad2be6e0b16ca24e0cd</Hash>
</Codenesium>*/