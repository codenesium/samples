using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Location")]
        [Trait("Area", "DALMapper")]
        public class TestDALLocationActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALLocationMapper();

                        var bo = new BOLocation();

                        bo.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

                        Location response = mapper.MapBOToEF(bo);

                        response.Availability.Should().Be(1);
                        response.CostRate.Should().Be(1);
                        response.LocationID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALLocationMapper();

                        Location entity = new Location();

                        entity.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

                        BOLocation  response = mapper.MapEFToBO(entity);

                        response.Availability.Should().Be(1);
                        response.CostRate.Should().Be(1);
                        response.LocationID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALLocationMapper();

                        Location entity = new Location();

                        entity.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

                        List<BOLocation> response = mapper.MapEFToBO(new List<Location>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>9457cc1efb5494e7094d4cd6a4ed2933</Hash>
</Codenesium>*/