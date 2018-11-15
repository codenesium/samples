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
	[Trait("Table", "ProductCategory")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLProductCategoryMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLProductCategoryMapper();
			ApiProductCategoryServerRequestModel model = new ApiProductCategoryServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			BOProductCategory response = mapper.MapModelToBO(1, model);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLProductCategoryMapper();
			BOProductCategory bo = new BOProductCategory();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			ApiProductCategoryServerResponseModel response = mapper.MapBOToModel(bo);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.ProductCategoryID.Should().Be(1);
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLProductCategoryMapper();
			BOProductCategory bo = new BOProductCategory();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			List<ApiProductCategoryServerResponseModel> response = mapper.MapBOToModel(new List<BOProductCategory>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>69ac58ff655c1468685f1c4d7f18a238</Hash>
</Codenesium>*/