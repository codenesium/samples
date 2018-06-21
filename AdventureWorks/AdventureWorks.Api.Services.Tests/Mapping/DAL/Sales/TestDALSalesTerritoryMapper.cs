using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "SalesTerritory")]
        [Trait("Area", "DALMapper")]
        public class TestDALSalesTerritoryMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALSalesTerritoryMapper();
                        var bo = new BOSalesTerritory();
                        bo.SetProperties(1, 1, 1, "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1);

                        SalesTerritory response = mapper.MapBOToEF(bo);

                        response.CostLastYear.Should().Be(1);
                        response.CostYTD.Should().Be(1);
                        response.CountryRegionCode.Should().Be("A");
                        response.@Group.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.SalesLastYear.Should().Be(1);
                        response.SalesYTD.Should().Be(1);
                        response.TerritoryID.Should().Be(1);
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALSalesTerritoryMapper();
                        SalesTerritory entity = new SalesTerritory();
                        entity.SetProperties(1, 1, "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1, 1);

                        BOSalesTerritory response = mapper.MapEFToBO(entity);

                        response.CostLastYear.Should().Be(1);
                        response.CostYTD.Should().Be(1);
                        response.CountryRegionCode.Should().Be("A");
                        response.@Group.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.SalesLastYear.Should().Be(1);
                        response.SalesYTD.Should().Be(1);
                        response.TerritoryID.Should().Be(1);
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALSalesTerritoryMapper();
                        SalesTerritory entity = new SalesTerritory();
                        entity.SetProperties(1, 1, "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1, 1);

                        List<BOSalesTerritory> response = mapper.MapEFToBO(new List<SalesTerritory>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>fe0dce42d1cf767ca7037d08a8232048</Hash>
</Codenesium>*/