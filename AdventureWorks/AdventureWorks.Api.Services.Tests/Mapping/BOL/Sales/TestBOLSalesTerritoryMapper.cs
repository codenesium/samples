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
        [Trait("Table", "SalesTerritory")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLSalesTerritoryActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLSalesTerritoryMapper();

                        ApiSalesTerritoryRequestModel model = new ApiSalesTerritoryRequestModel();

                        model.SetProperties(1, 1, "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1);
                        BOSalesTerritory response = mapper.MapModelToBO(1, model);

                        response.CostLastYear.Should().Be(1);
                        response.CostYTD.Should().Be(1);
                        response.CountryRegionCode.Should().Be("A");
                        response.@Group.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.SalesLastYear.Should().Be(1);
                        response.SalesYTD.Should().Be(1);
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLSalesTerritoryMapper();

                        BOSalesTerritory bo = new BOSalesTerritory();

                        bo.SetProperties(1, 1, 1, "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1);
                        ApiSalesTerritoryResponseModel response = mapper.MapBOToModel(bo);

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
                public void MapBOToModelList()
                {
                        var mapper = new BOLSalesTerritoryMapper();

                        BOSalesTerritory bo = new BOSalesTerritory();

                        bo.SetProperties(1, 1, 1, "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1);
                        List<ApiSalesTerritoryResponseModel> response = mapper.MapBOToModel(new List<BOSalesTerritory>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>09ac30a06dd5e3315089ee59c8824bbe</Hash>
</Codenesium>*/