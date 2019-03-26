using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "WorkOrder")]
	[Trait("Area", "ApiModel")]
	public class TestApiWorkOrderModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiWorkOrderModelMapper();
			var model = new ApiWorkOrderClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			ApiWorkOrderClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
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
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiWorkOrderModelMapper();
			var model = new ApiWorkOrderClientResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			ApiWorkOrderClientRequestModel response = mapper.MapClientResponseToRequest(model);
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
	}
}

/*<Codenesium>
    <Hash>1e7a384245e91ff9451bb6925c1cea45</Hash>
</Codenesium>*/