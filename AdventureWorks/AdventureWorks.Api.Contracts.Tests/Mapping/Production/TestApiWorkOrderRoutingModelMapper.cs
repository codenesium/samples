using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
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
                        model.SetProperties(1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1m, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"));
                        ApiWorkOrderRoutingResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.ActualCost.Should().Be(1m);
                        response.ActualEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ActualResourceHr.Should().Be(1m);
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
                public void MapResponseToRequest()
                {
                        var mapper = new ApiWorkOrderRoutingModelMapper();
                        var model = new ApiWorkOrderRoutingResponseModel();
                        model.SetProperties(1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1m, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"));
                        ApiWorkOrderRoutingRequestModel response = mapper.MapResponseToRequest(model);

                        response.ActualCost.Should().Be(1m);
                        response.ActualEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ActualResourceHr.Should().Be(1m);
                        response.ActualStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.LocationID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.OperationSequence.Should().Be(1);
                        response.PlannedCost.Should().Be(1m);
                        response.ProductID.Should().Be(1);
                        response.ScheduledEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ScheduledStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                }

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiWorkOrderRoutingModelMapper();
                        var model = new ApiWorkOrderRoutingRequestModel();
                        model.SetProperties(1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1m, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"));

                        JsonPatchDocument<ApiWorkOrderRoutingRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiWorkOrderRoutingRequestModel();
                        patch.ApplyTo(response);

                        response.ActualCost.Should().Be(1m);
                        response.ActualEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ActualResourceHr.Should().Be(1m);
                        response.ActualStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.LocationID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.OperationSequence.Should().Be(1);
                        response.PlannedCost.Should().Be(1m);
                        response.ProductID.Should().Be(1);
                        response.ScheduledEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ScheduledStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                }
        }
}

/*<Codenesium>
    <Hash>4fee1a46c03c736f62954643c50c52e2</Hash>
</Codenesium>*/