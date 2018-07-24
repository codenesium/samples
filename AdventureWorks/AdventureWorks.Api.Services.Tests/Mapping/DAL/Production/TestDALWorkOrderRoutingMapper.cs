using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "WorkOrderRouting")]
        [Trait("Area", "DALMapper")]
        public class TestDALWorkOrderRoutingMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALWorkOrderRoutingMapper();
                        var bo = new BOWorkOrderRouting();
                        bo.SetProperties(1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1m, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"));

                        WorkOrderRouting response = mapper.MapBOToEF(bo);

                        response.ActualCost.Should().Be(1m);
                        response.ActualEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ActualResourceHr.Should().Be(1);
                        response.ActualStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.LocationID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.OperationSequence.Should().Be(1);
                        response.PlannedCost.Should().Be(1m);
                        response.ProductID.Should().Be(1);
                        response.ScheduledEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ScheduledStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.WorkOrderID.Should().Be(1);
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALWorkOrderRoutingMapper();
                        WorkOrderRouting entity = new WorkOrderRouting();
                        entity.SetProperties(1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1m, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1);

                        BOWorkOrderRouting response = mapper.MapEFToBO(entity);

                        response.ActualCost.Should().Be(1m);
                        response.ActualEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ActualResourceHr.Should().Be(1);
                        response.ActualStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.LocationID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.OperationSequence.Should().Be(1);
                        response.PlannedCost.Should().Be(1m);
                        response.ProductID.Should().Be(1);
                        response.ScheduledEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ScheduledStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.WorkOrderID.Should().Be(1);
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALWorkOrderRoutingMapper();
                        WorkOrderRouting entity = new WorkOrderRouting();
                        entity.SetProperties(1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1m, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1);

                        List<BOWorkOrderRouting> response = mapper.MapEFToBO(new List<WorkOrderRouting>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>60997960505416feadb3fe98bc7f1997</Hash>
</Codenesium>*/