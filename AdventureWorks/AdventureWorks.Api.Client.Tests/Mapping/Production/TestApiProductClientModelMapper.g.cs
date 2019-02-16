using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Product")]
	[Trait("Area", "ApiModel")]
	public class TestApiProductModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiProductModelMapper();
			var model = new ApiProductClientRequestModel();
			model.SetProperties("A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), true, 1m, true, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1, "A", 1, 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1m, "A", 1, "A");
			ApiProductClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Color.Should().Be("A");
			response.DaysToManufacture.Should().Be(1);
			response.DiscontinuedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FinishedGoodsFlag.Should().Be(true);
			response.ListPrice.Should().Be(1m);
			response.MakeFlag.Should().Be(true);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.ProductLine.Should().Be("A");
			response.ProductModelID.Should().Be(1);
			response.ProductNumber.Should().Be("A");
			response.ProductSubcategoryID.Should().Be(1);
			response.ReorderPoint.Should().Be(1);
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SafetyStockLevel.Should().Be(1);
			response.SellEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.SellStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Size.Should().Be("A");
			response.SizeUnitMeasureCode.Should().Be("A");
			response.StandardCost.Should().Be(1m);
			response.Style.Should().Be("A");
			response.Weight.Should().Be(1);
			response.WeightUnitMeasureCode.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiProductModelMapper();
			var model = new ApiProductClientResponseModel();
			model.SetProperties(1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), true, 1m, true, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1, "A", 1, 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1m, "A", 1, "A");
			ApiProductClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Color.Should().Be("A");
			response.DaysToManufacture.Should().Be(1);
			response.DiscontinuedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FinishedGoodsFlag.Should().Be(true);
			response.ListPrice.Should().Be(1m);
			response.MakeFlag.Should().Be(true);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.ProductLine.Should().Be("A");
			response.ProductModelID.Should().Be(1);
			response.ProductNumber.Should().Be("A");
			response.ProductSubcategoryID.Should().Be(1);
			response.ReorderPoint.Should().Be(1);
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SafetyStockLevel.Should().Be(1);
			response.SellEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.SellStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Size.Should().Be("A");
			response.SizeUnitMeasureCode.Should().Be("A");
			response.StandardCost.Should().Be(1m);
			response.Style.Should().Be("A");
			response.Weight.Should().Be(1);
			response.WeightUnitMeasureCode.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>c02c1b26defa12d0d34ed8a870800f06</Hash>
</Codenesium>*/