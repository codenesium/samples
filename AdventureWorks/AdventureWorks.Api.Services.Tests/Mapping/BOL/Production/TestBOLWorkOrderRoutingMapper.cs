using AdventureWorksNS.Api.Contracts;
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
	[Trait("Area", "BOLMapper")]
	public class TestBOLWorkOrderRoutingMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLWorkOrderRoutingMapper();
			ApiWorkOrderRoutingRequestModel model = new ApiWorkOrderRoutingRequestModel();
			model.SetProperties(1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1m, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"));
			BOWorkOrderRouting response = mapper.MapModelToBO(1, model);

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
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLWorkOrderRoutingMapper();
			BOWorkOrderRouting bo = new BOWorkOrderRouting();
			bo.SetProperties(1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1m, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"));
			ApiWorkOrderRoutingResponseModel response = mapper.MapBOToModel(bo);

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
		public void MapBOToModelList()
		{
			var mapper = new BOLWorkOrderRoutingMapper();
			BOWorkOrderRouting bo = new BOWorkOrderRouting();
			bo.SetProperties(1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1m, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"));
			List<ApiWorkOrderRoutingResponseModel> response = mapper.MapBOToModel(new List<BOWorkOrderRouting>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>b622785c6e60f40f1750dab05ba9b61b</Hash>
</Codenesium>*/