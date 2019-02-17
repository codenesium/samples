using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SalesOrderHeader")]
	[Trait("Area", "DALMapper")]
	public class TestDALSalesOrderHeaderMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALSalesOrderHeaderMapper();
			ApiSalesOrderHeaderServerRequestModel model = new ApiSalesOrderHeaderServerRequestModel();
			model.SetProperties("A", 1, "A", "A", 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), true, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1m, 1m, 1, 1m);
			SalesOrderHeader response = mapper.MapModelToEntity(1, model);

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
		public void MapEntityToModel()
		{
			var mapper = new DALSalesOrderHeaderMapper();
			SalesOrderHeader item = new SalesOrderHeader();
			item.SetProperties(1, "A", 1, "A", "A", 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), true, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1m, 1m, 1, 1m);
			ApiSalesOrderHeaderServerResponseModel response = mapper.MapEntityToModel(item);

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
		public void MapEntityToModelList()
		{
			var mapper = new DALSalesOrderHeaderMapper();
			SalesOrderHeader item = new SalesOrderHeader();
			item.SetProperties(1, "A", 1, "A", "A", 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), true, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1m, 1m, 1, 1m);
			List<ApiSalesOrderHeaderServerResponseModel> response = mapper.MapEntityToModel(new List<SalesOrderHeader>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>38b970211125dbd26553ca78898941dd</Hash>
</Codenesium>*/