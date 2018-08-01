using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Product")]
	[Trait("Area", "ApiModel")]
	public class TestApiProductModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiProductModelMapper();
			var model = new ApiProductRequestModel();
			model.SetProperties("A", "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), true, 1m, true, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1, "A", 1, 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1m, "A", 1, "A");
			ApiProductResponseModel response = mapper.MapRequestToResponse(1, model);

			response.@Class.Should().Be("A");
			response.Color.Should().Be("A");
			response.DaysToManufacture.Should().Be(1);
			response.DiscontinuedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FinishedGoodsFlag.Should().Be(true);
			response.ListPrice.Should().Be(1m);
			response.MakeFlag.Should().Be(true);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.ProductID.Should().Be(1);
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
		public void MapResponseToRequest()
		{
			var mapper = new ApiProductModelMapper();
			var model = new ApiProductResponseModel();
			model.SetProperties(1, "A", "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), true, 1m, true, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1, "A", 1, 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1m, "A", 1, "A");
			ApiProductRequestModel response = mapper.MapResponseToRequest(model);

			response.@Class.Should().Be("A");
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
		public void CreatePatch()
		{
			var mapper = new ApiProductModelMapper();
			var model = new ApiProductRequestModel();
			model.SetProperties("A", "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), true, 1m, true, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1, "A", 1, 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1m, "A", 1, "A");

			JsonPatchDocument<ApiProductRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiProductRequestModel();
			patch.ApplyTo(response);
			response.@Class.Should().Be("A");
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
    <Hash>e5d72fec24858da0431b8f9cb01df67d</Hash>
</Codenesium>*/