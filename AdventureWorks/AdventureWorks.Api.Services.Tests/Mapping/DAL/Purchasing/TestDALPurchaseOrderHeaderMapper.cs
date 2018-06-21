using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "PurchaseOrderHeader")]
        [Trait("Area", "DALMapper")]
        public class TestDALPurchaseOrderHeaderMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALPurchaseOrderHeaderMapper();
                        var bo = new BOPurchaseOrderHeader();
                        bo.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, 1, 1);

                        PurchaseOrderHeader response = mapper.MapBOToEF(bo);

                        response.EmployeeID.Should().Be(1);
                        response.Freight.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.OrderDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.PurchaseOrderID.Should().Be(1);
                        response.RevisionNumber.Should().Be(1);
                        response.ShipDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ShipMethodID.Should().Be(1);
                        response.Status.Should().Be(1);
                        response.SubTotal.Should().Be(1);
                        response.TaxAmt.Should().Be(1);
                        response.TotalDue.Should().Be(1);
                        response.VendorID.Should().Be(1);
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALPurchaseOrderHeaderMapper();
                        PurchaseOrderHeader entity = new PurchaseOrderHeader();
                        entity.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, 1, 1);

                        BOPurchaseOrderHeader response = mapper.MapEFToBO(entity);

                        response.EmployeeID.Should().Be(1);
                        response.Freight.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.OrderDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.PurchaseOrderID.Should().Be(1);
                        response.RevisionNumber.Should().Be(1);
                        response.ShipDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ShipMethodID.Should().Be(1);
                        response.Status.Should().Be(1);
                        response.SubTotal.Should().Be(1);
                        response.TaxAmt.Should().Be(1);
                        response.TotalDue.Should().Be(1);
                        response.VendorID.Should().Be(1);
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALPurchaseOrderHeaderMapper();
                        PurchaseOrderHeader entity = new PurchaseOrderHeader();
                        entity.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, 1, 1);

                        List<BOPurchaseOrderHeader> response = mapper.MapEFToBO(new List<PurchaseOrderHeader>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>03357db6c5d36dcd498abde1c7bd1b16</Hash>
</Codenesium>*/