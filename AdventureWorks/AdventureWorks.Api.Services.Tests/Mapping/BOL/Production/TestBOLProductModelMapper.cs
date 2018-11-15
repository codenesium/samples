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
	[Trait("Table", "ProductModel")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLProductModelMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLProductModelMapper();
			ApiProductModelServerRequestModel model = new ApiProductModelServerRequestModel();
			model.SetProperties("A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			BOProductModel response = mapper.MapModelToBO(1, model);

			response.CatalogDescription.Should().Be("A");
			response.Instruction.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLProductModelMapper();
			BOProductModel bo = new BOProductModel();
			bo.SetProperties(1, "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			ApiProductModelServerResponseModel response = mapper.MapBOToModel(bo);

			response.CatalogDescription.Should().Be("A");
			response.Instruction.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.ProductModelID.Should().Be(1);
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLProductModelMapper();
			BOProductModel bo = new BOProductModel();
			bo.SetProperties(1, "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			List<ApiProductModelServerResponseModel> response = mapper.MapBOToModel(new List<BOProductModel>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>deff9dde8900d6f3f94b54687a586e62</Hash>
</Codenesium>*/