using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "SalesOrderHeader")]
        [Trait("Area", "ApiModel")]
        public class TestApiSalesOrderHeaderModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiSalesOrderHeaderModelMapper();
                        var model = new ApiSalesOrderHeaderRequestModel();
                        model.SetProperties("A", 1, "A", "A", 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), true, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1m, 1m, 1, 1m);
                        ApiSalesOrderHeaderResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.AccountNumber.Should().Be("A");
                        response.BillToAddressID.Should().Be(1);
                        response.Comment.Should().Be("A");
                        response.CreditCardApprovalCode.Should().Be("A");
                        response.CreditCardID.Should().Be(1);
                        response.CurrencyRateID.Should().Be(1);
                        response.CustomerID.Should().Be(1);
                        response.DueDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Freight.Should().Be(1m);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.OnlineOrderFlag.Should().Be(true);
                        response.OrderDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.PurchaseOrderNumber.Should().Be("A");
                        response.RevisionNumber.Should().Be(1);
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.SalesOrderID.Should().Be(1);
                        response.SalesOrderNumber.Should().Be("A");
                        response.SalesPersonID.Should().Be(1);
                        response.ShipDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ShipMethodID.Should().Be(1);
                        response.ShipToAddressID.Should().Be(1);
                        response.Status.Should().Be(1);
                        response.SubTotal.Should().Be(1m);
                        response.TaxAmt.Should().Be(1m);
                        response.TerritoryID.Should().Be(1);
                        response.TotalDue.Should().Be(1m);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiSalesOrderHeaderModelMapper();
                        var model = new ApiSalesOrderHeaderResponseModel();
                        model.SetProperties(1, "A", 1, "A", "A", 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), true, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1m, 1m, 1, 1m);
                        ApiSalesOrderHeaderRequestModel response = mapper.MapResponseToRequest(model);

                        response.AccountNumber.Should().Be("A");
                        response.BillToAddressID.Should().Be(1);
                        response.Comment.Should().Be("A");
                        response.CreditCardApprovalCode.Should().Be("A");
                        response.CreditCardID.Should().Be(1);
                        response.CurrencyRateID.Should().Be(1);
                        response.CustomerID.Should().Be(1);
                        response.DueDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Freight.Should().Be(1m);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.OnlineOrderFlag.Should().Be(true);
                        response.OrderDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.PurchaseOrderNumber.Should().Be("A");
                        response.RevisionNumber.Should().Be(1);
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.SalesOrderNumber.Should().Be("A");
                        response.SalesPersonID.Should().Be(1);
                        response.ShipDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ShipMethodID.Should().Be(1);
                        response.ShipToAddressID.Should().Be(1);
                        response.Status.Should().Be(1);
                        response.SubTotal.Should().Be(1m);
                        response.TaxAmt.Should().Be(1m);
                        response.TerritoryID.Should().Be(1);
                        response.TotalDue.Should().Be(1m);
                }

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiSalesOrderHeaderModelMapper();
                        var model = new ApiSalesOrderHeaderRequestModel();
                        model.SetProperties("A", 1, "A", "A", 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), true, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1m, 1m, 1, 1m);

                        JsonPatchDocument<ApiSalesOrderHeaderRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiSalesOrderHeaderRequestModel();
                        patch.ApplyTo(response);

                        response.AccountNumber.Should().Be("A");
                        response.BillToAddressID.Should().Be(1);
                        response.Comment.Should().Be("A");
                        response.CreditCardApprovalCode.Should().Be("A");
                        response.CreditCardID.Should().Be(1);
                        response.CurrencyRateID.Should().Be(1);
                        response.CustomerID.Should().Be(1);
                        response.DueDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Freight.Should().Be(1m);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.OnlineOrderFlag.Should().Be(true);
                        response.OrderDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.PurchaseOrderNumber.Should().Be("A");
                        response.RevisionNumber.Should().Be(1);
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.SalesOrderNumber.Should().Be("A");
                        response.SalesPersonID.Should().Be(1);
                        response.ShipDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ShipMethodID.Should().Be(1);
                        response.ShipToAddressID.Should().Be(1);
                        response.Status.Should().Be(1);
                        response.SubTotal.Should().Be(1m);
                        response.TaxAmt.Should().Be(1m);
                        response.TerritoryID.Should().Be(1);
                        response.TotalDue.Should().Be(1m);
                }
        }
}

/*<Codenesium>
    <Hash>1f3bad756407a4dd38b672eb779609e1</Hash>
</Codenesium>*/