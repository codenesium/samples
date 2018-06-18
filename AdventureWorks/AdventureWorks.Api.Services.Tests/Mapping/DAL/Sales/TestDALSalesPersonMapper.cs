using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "SalesPerson")]
        [Trait("Area", "DALMapper")]
        public class TestDALSalesPersonActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALSalesPersonMapper();

                        var bo = new BOSalesPerson();

                        bo.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1, 1, 1);

                        SalesPerson response = mapper.MapBOToEF(bo);

                        response.Bonus.Should().Be(1);
                        response.BusinessEntityID.Should().Be(1);
                        response.CommissionPct.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.SalesLastYear.Should().Be(1);
                        response.SalesQuota.Should().Be(1);
                        response.SalesYTD.Should().Be(1);
                        response.TerritoryID.Should().Be(1);
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALSalesPersonMapper();

                        SalesPerson entity = new SalesPerson();

                        entity.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1, 1, 1);

                        BOSalesPerson  response = mapper.MapEFToBO(entity);

                        response.Bonus.Should().Be(1);
                        response.BusinessEntityID.Should().Be(1);
                        response.CommissionPct.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.SalesLastYear.Should().Be(1);
                        response.SalesQuota.Should().Be(1);
                        response.SalesYTD.Should().Be(1);
                        response.TerritoryID.Should().Be(1);
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALSalesPersonMapper();

                        SalesPerson entity = new SalesPerson();

                        entity.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1, 1, 1);

                        List<BOSalesPerson> response = mapper.MapEFToBO(new List<SalesPerson>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>3550742e6503078b08f7889e6d1600b1</Hash>
</Codenesium>*/