using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "WorkOrder")]
        [Trait("Area", "DALMapper")]
        public class TestDALWorkOrderActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALWorkOrderMapper();

                        var bo = new BOWorkOrder();

                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1);

                        WorkOrder response = mapper.MapBOToEF(bo);

                        response.DueDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.OrderQty.Should().Be(1);
                        response.ProductID.Should().Be(1);
                        response.ScrappedQty.Should().Be(1);
                        response.ScrapReasonID.Should().Be(1);
                        response.StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.StockedQty.Should().Be(1);
                        response.WorkOrderID.Should().Be(1);
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALWorkOrderMapper();

                        WorkOrder entity = new WorkOrder();

                        entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1);

                        BOWorkOrder  response = mapper.MapEFToBO(entity);

                        response.DueDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.OrderQty.Should().Be(1);
                        response.ProductID.Should().Be(1);
                        response.ScrappedQty.Should().Be(1);
                        response.ScrapReasonID.Should().Be(1);
                        response.StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.StockedQty.Should().Be(1);
                        response.WorkOrderID.Should().Be(1);
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALWorkOrderMapper();

                        WorkOrder entity = new WorkOrder();

                        entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1);

                        List<BOWorkOrder> response = mapper.MapEFToBO(new List<WorkOrder>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>bf93fa44c997ecf9e7a6700680f7f52e</Hash>
</Codenesium>*/