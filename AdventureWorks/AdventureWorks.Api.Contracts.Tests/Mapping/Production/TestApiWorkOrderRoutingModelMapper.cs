using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "WorkOrderRouting")]
        [Trait("Area", "ApiModel")]
        public class TestApiWorkOrderRoutingModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiWorkOrderRoutingModelMapper();
                        var model = new ApiWorkOrderRoutingRequestModel();
                        model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"));
                        ApiWorkOrderRoutingResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.ActualCost.Should().Be(1);
                        response.ActualEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ActualResourceHrs.Should().Be(1);
                        response.ActualStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.LocationID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.OperationSequence.Should().Be(1);
                        response.PlannedCost.Should().Be(1);
                        response.ProductID.Should().Be(1);
                        response.ScheduledEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ScheduledStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.WorkOrderID.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiWorkOrderRoutingModelMapper();
                        var model = new ApiWorkOrderRoutingResponseModel();
                        model.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"));
                        ApiWorkOrderRoutingRequestModel response = mapper.MapResponseToRequest(model);

                        response.ActualCost.Should().Be(1);
                        response.ActualEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ActualResourceHrs.Should().Be(1);
                        response.ActualStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.LocationID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.OperationSequence.Should().Be(1);
                        response.PlannedCost.Should().Be(1);
                        response.ProductID.Should().Be(1);
                        response.ScheduledEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ScheduledStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                }
        }
}

/*<Codenesium>
    <Hash>25b729cdc5cfc3c7a357f2710b796046</Hash>
</Codenesium>*/