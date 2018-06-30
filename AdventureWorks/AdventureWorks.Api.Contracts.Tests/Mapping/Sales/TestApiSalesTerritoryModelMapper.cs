using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "SalesTerritory")]
        [Trait("Area", "ApiModel")]
        public class TestApiSalesTerritoryModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiSalesTerritoryModelMapper();
                        var model = new ApiSalesTerritoryRequestModel();
                        model.SetProperties(1, 1, "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1);
                        ApiSalesTerritoryResponseModel response = mapper.MapRequestToResponse(1, model);

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
                public void MapResponseToRequest()
                {
                        var mapper = new ApiSalesTerritoryModelMapper();
                        var model = new ApiSalesTerritoryResponseModel();
                        model.SetProperties(1, 1, 1, "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1);
                        ApiSalesTerritoryRequestModel response = mapper.MapResponseToRequest(model);

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
        }
}

/*<Codenesium>
    <Hash>3eb38d6da3b1b4c5714b5d75104aa30e</Hash>
</Codenesium>*/