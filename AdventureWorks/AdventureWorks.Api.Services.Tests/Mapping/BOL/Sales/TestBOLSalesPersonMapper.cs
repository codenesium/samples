using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "SalesPerson")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLSalesPersonMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLSalesPersonMapper();
                        ApiSalesPersonRequestModel model = new ApiSalesPersonRequestModel();
                        model.SetProperties(1m, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1m, 1m, 1);
                        BOSalesPerson response = mapper.MapModelToBO(1, model);

                        response.Bonus.Should().Be(1m);
                        response.CommissionPct.Should().Be(1m);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.SalesLastYear.Should().Be(1m);
                        response.SalesQuota.Should().Be(1m);
                        response.SalesYTD.Should().Be(1m);
                        response.TerritoryID.Should().Be(1);
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLSalesPersonMapper();
                        BOSalesPerson bo = new BOSalesPerson();
                        bo.SetProperties(1, 1m, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1m, 1m, 1);
                        ApiSalesPersonResponseModel response = mapper.MapBOToModel(bo);

                        response.Bonus.Should().Be(1m);
                        response.BusinessEntityID.Should().Be(1);
                        response.CommissionPct.Should().Be(1m);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.SalesLastYear.Should().Be(1m);
                        response.SalesQuota.Should().Be(1m);
                        response.SalesYTD.Should().Be(1m);
                        response.TerritoryID.Should().Be(1);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLSalesPersonMapper();
                        BOSalesPerson bo = new BOSalesPerson();
                        bo.SetProperties(1, 1m, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1m, 1m, 1);
                        List<ApiSalesPersonResponseModel> response = mapper.MapBOToModel(new List<BOSalesPerson>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>32438283ec0c39a48cd5b99460274217</Hash>
</Codenesium>*/