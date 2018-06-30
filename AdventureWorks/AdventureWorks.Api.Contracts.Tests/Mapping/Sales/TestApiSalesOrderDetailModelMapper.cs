using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "SalesOrderDetail")]
        [Trait("Area", "ApiModel")]
        public class TestApiSalesOrderDetailModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiSalesOrderDetailModelMapper();
                        var model = new ApiSalesOrderDetailRequestModel();
                        model.SetProperties("A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1, 1, 1);
                        ApiSalesOrderDetailResponseModel response = mapper.MapRequestToResponse(1, model);

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
                public void MapResponseToRequest()
                {
                        var mapper = new ApiSalesOrderDetailModelMapper();
                        var model = new ApiSalesOrderDetailResponseModel();
                        model.SetProperties(1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1, 1, 1);
                        ApiSalesOrderDetailRequestModel response = mapper.MapResponseToRequest(model);

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
        }
}

/*<Codenesium>
    <Hash>7a8331f6d2207896ae3e6432d32033e6</Hash>
</Codenesium>*/