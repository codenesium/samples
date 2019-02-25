using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ProductSubcategory")]
	[Trait("Area", "DALMapper")]
	public class TestDALProductSubcategoryMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALProductSubcategoryMapper();
			ApiProductSubcategoryServerRequestModel model = new ApiProductSubcategoryServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			ProductSubcategory response = mapper.MapModelToEntity(1, model);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.ProductCategoryID.Should().Be(1);
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALProductSubcategoryMapper();
			ProductSubcategory item = new ProductSubcategory();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			ApiProductSubcategoryServerResponseModel response = mapper.MapEntityToModel(item);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.ProductCategoryID.Should().Be(1);
			response.ProductSubcategoryID.Should().Be(1);
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALProductSubcategoryMapper();
			ProductSubcategory item = new ProductSubcategory();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			List<ApiProductSubcategoryServerResponseModel> response = mapper.MapEntityToModel(new List<ProductSubcategory>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>fbf126015c2f2473f6dcd834aa7fdced</Hash>
</Codenesium>*/