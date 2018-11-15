using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SalesOrderHeader")]
	[Trait("Area", "ApiModel")]
	public class TestApiSalesOrderHeaderServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiSalesOrderHeaderServerModelMapper();
			var model = new ApiSalesOrderHeaderServerRequestModel();
			model.SetProperties("A", 1, "A", "A", 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), true, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1m, 1m, 1, 1m);
			ApiSalesOrderHeaderServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
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
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiSalesOrderHeaderServerModelMapper();
			var model = new ApiSalesOrderHeaderServerResponseModel();
			model.SetProperties(1, "A", 1, "A", "A", 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), true, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1m, 1m, 1, 1m);
			ApiSalesOrderHeaderServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
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
			var mapper = new ApiSalesOrderHeaderServerModelMapper();
			var model = new ApiSalesOrderHeaderServerRequestModel();
			model.SetProperties("A", 1, "A", "A", 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), true, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1m, 1m, 1, 1m);

			JsonPatchDocument<ApiSalesOrderHeaderServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiSalesOrderHeaderServerRequestModel();
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
    <Hash>c480e2111c1721846cea646e3344454c</Hash>
</Codenesium>*/