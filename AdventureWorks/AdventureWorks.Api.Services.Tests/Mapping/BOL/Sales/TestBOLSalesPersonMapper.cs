using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "SalesPerson")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLSalesPersonActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLSalesPersonMapper();

                        ApiSalesPersonRequestModel model = new ApiSalesPersonRequestModel();

                        model.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1, 1, 1);
                        BOSalesPerson response = mapper.MapModelToBO(1, model);

                        response.Bonus.Should().Be(1);
                        response.CommissionPct.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.SalesLastYear.Should().Be(1);
                        response.SalesQuota.Should().Be(1);
                        response.SalesYTD.Should().Be(1);
                        response.TerritoryID.Should().Be(1);
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLSalesPersonMapper();

                        BOSalesPerson bo = new BOSalesPerson();

                        bo.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1, 1, 1);
                        ApiSalesPersonResponseModel response = mapper.MapBOToModel(bo);

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
                public void MapBOToModelList()
                {
                        var mapper = new BOLSalesPersonMapper();

                        BOSalesPerson bo = new BOSalesPerson();

                        bo.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1, 1, 1);
                        List<ApiSalesPersonResponseModel> response = mapper.MapBOToModel(new List<BOSalesPerson>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>df85e75e81e6b39ac56b5550ff08be7a</Hash>
</Codenesium>*/