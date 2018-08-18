using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ProductSubcategory")]
	[Trait("Area", "DALMapper")]
	public class TestDALProductSubcategoryMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALProductSubcategoryMapper();
			var bo = new BOProductSubcategory();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

			ProductSubcategory response = mapper.MapBOToEF(bo);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.ProductCategoryID.Should().Be(1);
			response.ProductSubcategoryID.Should().Be(1);
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALProductSubcategoryMapper();
			ProductSubcategory entity = new ProductSubcategory();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

			BOProductSubcategory response = mapper.MapEFToBO(entity);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.ProductCategoryID.Should().Be(1);
			response.ProductSubcategoryID.Should().Be(1);
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALProductSubcategoryMapper();
			ProductSubcategory entity = new ProductSubcategory();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

			List<BOProductSubcategory> response = mapper.MapEFToBO(new List<ProductSubcategory>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>181683102e96d800014b13b69d1af532</Hash>
</Codenesium>*/