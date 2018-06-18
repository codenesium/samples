using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "PurchaseOrderDetail")]
        [Trait("Area", "DALMapper")]
        public class TestDALPurchaseOrderDetailActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALPurchaseOrderDetailMapper();

                        var bo = new BOPurchaseOrderDetail();

                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, 1, 1, 1);

                        PurchaseOrderDetail response = mapper.MapBOToEF(bo);

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
                public void MapEFToBO()
                {
                        var mapper = new DALPurchaseOrderDetailMapper();

                        PurchaseOrderDetail entity = new PurchaseOrderDetail();

                        entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, 1, 1, 1, 1);

                        BOPurchaseOrderDetail  response = mapper.MapEFToBO(entity);

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
                public void MapEFToBOList()
                {
                        var mapper = new DALPurchaseOrderDetailMapper();

                        PurchaseOrderDetail entity = new PurchaseOrderDetail();

                        entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, 1, 1, 1, 1);

                        List<BOPurchaseOrderDetail> response = mapper.MapEFToBO(new List<PurchaseOrderDetail>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>0b7bcd6786a839c7d0a3320efc512b94</Hash>
</Codenesium>*/