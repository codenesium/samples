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
        [Trait("Table", "Product")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLProductMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLProductMapper();
                        ApiProductRequestModel model = new ApiProductRequestModel();
                        model.SetProperties("A", "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), true, 1, true, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1, "A", 1, 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1, "A", 1, "A");
                        BOProduct response = mapper.MapModelToBO(1, model);

                        response.@Class.Should().Be("A");
                        response.Color.Should().Be("A");
                        response.DaysToManufacture.Should().Be(1);
                        response.DiscontinuedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.FinishedGoodsFlag.Should().Be(true);
                        response.ListPrice.Should().Be(1);
                        response.MakeFlag.Should().Be(true);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                        response.ProductLine.Should().Be("A");
                        response.ProductModelID.Should().Be(1);
                        response.ProductNumber.Should().Be("A");
                        response.ProductSubcategoryID.Should().Be(1);
                        response.ReorderPoint.Should().Be(1);
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.SafetyStockLevel.Should().Be(1);
                        response.SellEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.SellStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Size.Should().Be("A");
                        response.SizeUnitMeasureCode.Should().Be("A");
                        response.StandardCost.Should().Be(1);
                        response.Style.Should().Be("A");
                        response.Weight.Should().Be(1);
                        response.WeightUnitMeasureCode.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLProductMapper();
                        BOProduct bo = new BOProduct();
                        bo.SetProperties(1, "A", "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), true, 1, true, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1, "A", 1, 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1, "A", 1, "A");
                        ApiProductResponseModel response = mapper.MapBOToModel(bo);

                        response.@Class.Should().Be("A");
                        response.Color.Should().Be("A");
                        response.DaysToManufacture.Should().Be(1);
                        response.DiscontinuedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.FinishedGoodsFlag.Should().Be(true);
                        response.ListPrice.Should().Be(1);
                        response.MakeFlag.Should().Be(true);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                        response.ProductID.Should().Be(1);
                        response.ProductLine.Should().Be("A");
                        response.ProductModelID.Should().Be(1);
                        response.ProductNumber.Should().Be("A");
                        response.ProductSubcategoryID.Should().Be(1);
                        response.ReorderPoint.Should().Be(1);
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.SafetyStockLevel.Should().Be(1);
                        response.SellEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.SellStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Size.Should().Be("A");
                        response.SizeUnitMeasureCode.Should().Be("A");
                        response.StandardCost.Should().Be(1);
                        response.Style.Should().Be("A");
                        response.Weight.Should().Be(1);
                        response.WeightUnitMeasureCode.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLProductMapper();
                        BOProduct bo = new BOProduct();
                        bo.SetProperties(1, "A", "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), true, 1, true, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1, "A", 1, 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1, "A", 1, "A");
                        List<ApiProductResponseModel> response = mapper.MapBOToModel(new List<BOProduct>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>289ea36d66a6aa0293ba0895ac318a96</Hash>
</Codenesium>*/