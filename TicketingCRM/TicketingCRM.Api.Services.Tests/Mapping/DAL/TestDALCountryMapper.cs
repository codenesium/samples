using FluentAssertions;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.DataAccess;
using TicketingCRMNS.Api.Services;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Country")]
        [Trait("Area", "DALMapper")]
        public class TestDALCountryMapper
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

                        BOCountry response = mapper.MapEFToBO(entity);

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
    <Hash>1667e1f93603dd434a05a7189b6e98fc</Hash>
</Codenesium>*/