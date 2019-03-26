using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "WorkOrder")]
	[Trait("Area", "ApiModel")]
	public class TestApiWorkOrderServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiWorkOrderServerModelMapper();
			var model = new ApiWorkOrderServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			ApiWorkOrderServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
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
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiWorkOrderServerModelMapper();
			var model = new ApiWorkOrderServerResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			ApiWorkOrderServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
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
		public void CreatePatch()
		{
			var mapper = new ApiWorkOrderServerModelMapper();
			var model = new ApiWorkOrderServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1);

			JsonPatchDocument<ApiWorkOrderServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiWorkOrderServerRequestModel();
			patch.ApplyTo(response);
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
	}
}

/*<Codenesium>
    <Hash>91d3d6e4c326e1279070e65a8c9dfc75</Hash>
</Codenesium>*/