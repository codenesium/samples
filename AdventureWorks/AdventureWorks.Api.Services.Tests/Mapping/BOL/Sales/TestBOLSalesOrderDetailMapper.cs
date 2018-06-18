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
        [Trait("Table", "SalesOrderDetail")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLSalesOrderDetailActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLSalesOrderDetailMapper();

                        ApiSalesOrderDetailRequestModel model = new ApiSalesOrderDetailRequestModel();

                        model.SetProperties("A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1, 1, 1);
                        BOSalesOrderDetail response = mapper.MapModelToBO(1, model);

                        response.CarrierTrackingNumber.Should().Be("A");
                        response.LineTotal.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.OrderQty.Should().Be(1);
                        response.ProductID.Should().Be(1);
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.SalesOrderDetailID.Should().Be(1);
                        response.SpecialOfferID.Should().Be(1);
                        response.UnitPrice.Should().Be(1);
                        response.UnitPriceDiscount.Should().Be(1);
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLSalesOrderDetailMapper();

                        BOSalesOrderDetail bo = new BOSalesOrderDetail();

                        bo.SetProperties(1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1, 1, 1);
                        ApiSalesOrderDetailResponseModel response = mapper.MapBOToModel(bo);

                        response.CarrierTrackingNumber.Should().Be("A");
                        response.LineTotal.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.OrderQty.Should().Be(1);
                        response.ProductID.Should().Be(1);
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.SalesOrderDetailID.Should().Be(1);
                        response.SalesOrderID.Should().Be(1);
                        response.SpecialOfferID.Should().Be(1);
                        response.UnitPrice.Should().Be(1);
                        response.UnitPriceDiscount.Should().Be(1);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLSalesOrderDetailMapper();

                        BOSalesOrderDetail bo = new BOSalesOrderDetail();

                        bo.SetProperties(1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1, 1, 1);
                        List<ApiSalesOrderDetailResponseModel> response = mapper.MapBOToModel(new List<BOSalesOrderDetail>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>6a00a63ea646ef8a5c8aa26cc708ff39</Hash>
</Codenesium>*/