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
	[Trait("Table", "WorkOrder")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLWorkOrderMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLWorkOrderMapper();
			ApiWorkOrderServerRequestModel model = new ApiWorkOrderServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			BOWorkOrder response = mapper.MapModelToBO(1, model);

			response.DueDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.OrderQty.Should().Be(1);
			response.ProductID.Should().Be(1);
			response.ScrappedQty.Should().Be(1);
			response.ScrapReasonID.Should().Be(1);
			response.StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.StockedQty.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLWorkOrderMapper();
			BOWorkOrder bo = new BOWorkOrder();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			ApiWorkOrderServerResponseModel response = mapper.MapBOToModel(bo);

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
		public void MapBOToModelList()
		{
			var mapper = new BOLWorkOrderMapper();
			BOWorkOrder bo = new BOWorkOrder();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			List<ApiWorkOrderServerResponseModel> response = mapper.MapBOToModel(new List<BOWorkOrder>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>50f5f2c5f083c3811e62aee25619442f</Hash>
</Codenesium>*/