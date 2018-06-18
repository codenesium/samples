using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "SalesOrderHeader")]
        [Trait("Area", "DALMapper")]
        public class TestDALSalesOrderHeaderActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALSalesOrderHeaderMapper();

                        var bo = new BOSalesOrderHeader();

                        bo.SetProperties(1, "A", 1, "A", "A", 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), true, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, 1, 1, 1);

                        SalesOrderHeader response = mapper.MapBOToEF(bo);

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
                public void MapEFToBO()
                {
                        var mapper = new DALSalesOrderHeaderMapper();

                        SalesOrderHeader entity = new SalesOrderHeader();

                        entity.SetProperties("A", 1, "A", "A", 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), true, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, 1, 1, 1);

                        BOSalesOrderHeader  response = mapper.MapEFToBO(entity);

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
                public void MapEFToBOList()
                {
                        var mapper = new DALSalesOrderHeaderMapper();

                        SalesOrderHeader entity = new SalesOrderHeader();

                        entity.SetProperties("A", 1, "A", "A", 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), true, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, 1, 1, 1);

                        List<BOSalesOrderHeader> response = mapper.MapEFToBO(new List<SalesOrderHeader>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>1e2396f20157f95028137b74647c17ce</Hash>
</Codenesium>*/