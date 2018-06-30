using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
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
                        model.SetProperties("A", 1, "A", "A", 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), true, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, 1, 1, 1);
                        ApiSalesOrderHeaderResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.AccountNumber.Should().Be("A");
                        response.BillToAddressID.Should().Be(1);
                        response.Comment.Should().Be("A");
                        response.CreditCardApprovalCode.Should().Be("A");
                        response.CreditCardID.Should().Be(1);
                        response.CurrencyRateID.Should().Be(1);
                        response.CustomerID.Should().Be(1);
                        response.DueDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Freight.Should().Be(1);
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
                        response.SubTotal.Should().Be(1);
                        response.TaxAmt.Should().Be(1);
                        response.TerritoryID.Should().Be(1);
                        response.TotalDue.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiSalesOrderHeaderModelMapper();
                        var model = new ApiSalesOrderHeaderResponseModel();
                        model.SetProperties(1, "A", 1, "A", "A", 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), true, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, 1, 1, 1);
                        ApiSalesOrderHeaderRequestModel response = mapper.MapResponseToRequest(model);

                        response.AccountNumber.Should().Be("A");
                        response.BillToAddressID.Should().Be(1);
                        response.Comment.Should().Be("A");
                        response.CreditCardApprovalCode.Should().Be("A");
                        response.CreditCardID.Should().Be(1);
                        response.CurrencyRateID.Should().Be(1);
                        response.CustomerID.Should().Be(1);
                        response.DueDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Freight.Should().Be(1);
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
                        response.SubTotal.Should().Be(1);
                        response.TaxAmt.Should().Be(1);
                        response.TerritoryID.Should().Be(1);
                        response.TotalDue.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>0cf6af360969884e131c05e0f5209df3</Hash>
</Codenesium>*/