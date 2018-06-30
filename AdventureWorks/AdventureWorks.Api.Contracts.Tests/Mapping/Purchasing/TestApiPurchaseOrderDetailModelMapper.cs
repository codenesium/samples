using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "PurchaseOrderDetail")]
        [Trait("Area", "ApiModel")]
        public class TestApiPurchaseOrderDetailModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiPurchaseOrderDetailModelMapper();
                        var model = new ApiPurchaseOrderDetailRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, 1, 1, 1);
                        ApiPurchaseOrderDetailResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.DueDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.LineTotal.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.OrderQty.Should().Be(1);
                        response.ProductID.Should().Be(1);
                        response.PurchaseOrderDetailID.Should().Be(1);
                        response.PurchaseOrderID.Should().Be(1);
                        response.ReceivedQty.Should().Be(1);
                        response.RejectedQty.Should().Be(1);
                        response.StockedQty.Should().Be(1);
                        response.UnitPrice.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiPurchaseOrderDetailModelMapper();
                        var model = new ApiPurchaseOrderDetailResponseModel();
                        model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, 1, 1, 1);
                        ApiPurchaseOrderDetailRequestModel response = mapper.MapResponseToRequest(model);

                        response.DueDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.LineTotal.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.OrderQty.Should().Be(1);
                        response.ProductID.Should().Be(1);
                        response.PurchaseOrderDetailID.Should().Be(1);
                        response.ReceivedQty.Should().Be(1);
                        response.RejectedQty.Should().Be(1);
                        response.StockedQty.Should().Be(1);
                        response.UnitPrice.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>121a57305d70c9ec5c639578caab20fc</Hash>
</Codenesium>*/