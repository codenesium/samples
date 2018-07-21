using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
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
                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1m, 1m, 1m, 1m);
                        ApiPurchaseOrderDetailResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.DueDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.LineTotal.Should().Be(1m);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.OrderQty.Should().Be(1);
                        response.ProductID.Should().Be(1);
                        response.PurchaseOrderDetailID.Should().Be(1);
                        response.PurchaseOrderID.Should().Be(1);
                        response.ReceivedQty.Should().Be(1m);
                        response.RejectedQty.Should().Be(1m);
                        response.StockedQty.Should().Be(1m);
                        response.UnitPrice.Should().Be(1m);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiPurchaseOrderDetailModelMapper();
                        var model = new ApiPurchaseOrderDetailResponseModel();
                        model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1m, 1m, 1m, 1m);
                        ApiPurchaseOrderDetailRequestModel response = mapper.MapResponseToRequest(model);

                        response.DueDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.LineTotal.Should().Be(1m);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.OrderQty.Should().Be(1);
                        response.ProductID.Should().Be(1);
                        response.PurchaseOrderDetailID.Should().Be(1);
                        response.ReceivedQty.Should().Be(1m);
                        response.RejectedQty.Should().Be(1m);
                        response.StockedQty.Should().Be(1m);
                        response.UnitPrice.Should().Be(1m);
                }

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiPurchaseOrderDetailModelMapper();
                        var model = new ApiPurchaseOrderDetailRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1m, 1m, 1m, 1m);

                        JsonPatchDocument<ApiPurchaseOrderDetailRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiPurchaseOrderDetailRequestModel();
                        patch.ApplyTo(response);

                        response.DueDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.LineTotal.Should().Be(1m);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.OrderQty.Should().Be(1);
                        response.ProductID.Should().Be(1);
                        response.PurchaseOrderDetailID.Should().Be(1);
                        response.ReceivedQty.Should().Be(1m);
                        response.RejectedQty.Should().Be(1m);
                        response.StockedQty.Should().Be(1m);
                        response.UnitPrice.Should().Be(1m);
                }
        }
}

/*<Codenesium>
    <Hash>9d099ec1ad0134ff3b2d81685ccab73c</Hash>
</Codenesium>*/