using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Product")]
	[Trait("Area", "DALMapper")]
	public class TestDALProductMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALProductMapper();
			var bo = new BOProduct();
			bo.SetProperties(1, "A", "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), true, 1m, true, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1, "A", 1, 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1m, "A", 1, "A");

			Product response = mapper.MapBOToEF(bo);

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
		public void MapEFToBO()
		{
			var mapper = new DALProductMapper();
			Product entity = new Product();
			entity.SetProperties("A", "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), true, 1m, true, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, "A", 1, "A", 1, 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1m, "A", 1, "A");

			BOProduct response = mapper.MapEFToBO(entity);

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
		public void MapEFToBOList()
		{
			var mapper = new DALProductMapper();
			Product entity = new Product();
			entity.SetProperties("A", "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), true, 1m, true, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, "A", 1, "A", 1, 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1m, "A", 1, "A");

			List<BOProduct> response = mapper.MapEFToBO(new List<Product>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>9b800503a22254030fbe018acf77ce8c</Hash>
</Codenesium>*/