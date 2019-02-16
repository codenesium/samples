using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "WorkOrder")]
	[Trait("Area", "DALMapper")]
	public class TestDALWorkOrderMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new DALWorkOrderMapper();
			ApiWorkOrderServerRequestModel model = new ApiWorkOrderServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			WorkOrder response = mapper.MapModelToBO(1, model);

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
			var mapper = new DALWorkOrderMapper();
			WorkOrder item = new WorkOrder();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			ApiWorkOrderServerResponseModel response = mapper.MapBOToModel(item);

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
			var mapper = new DALWorkOrderMapper();
			WorkOrder item = new WorkOrder();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			List<ApiWorkOrderServerResponseModel> response = mapper.MapBOToModel(new List<WorkOrder>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>0ea14a8adb161134f82be991bdbe0e91</Hash>
</Codenesium>*/