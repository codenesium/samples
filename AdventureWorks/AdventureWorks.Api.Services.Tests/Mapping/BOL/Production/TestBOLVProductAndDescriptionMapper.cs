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
	[Trait("Table", "VProductAndDescription")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLVProductAndDescriptionMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLVProductAndDescriptionMapper();
			ApiVProductAndDescriptionRequestModel model = new ApiVProductAndDescriptionRequestModel();
			model.SetProperties("A", "A", 1, "A");
			BOVProductAndDescription response = mapper.MapModelToBO("A", model);

			response.Description.Should().Be("A");
			response.Name.Should().Be("A");
			response.ProductID.Should().Be(1);
			response.ProductModel.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLVProductAndDescriptionMapper();
			BOVProductAndDescription bo = new BOVProductAndDescription();
			bo.SetProperties("A", "A", "A", 1, "A");
			ApiVProductAndDescriptionResponseModel response = mapper.MapBOToModel(bo);

			response.CultureID.Should().Be("A");
			response.Description.Should().Be("A");
			response.Name.Should().Be("A");
			response.ProductID.Should().Be(1);
			response.ProductModel.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLVProductAndDescriptionMapper();
			BOVProductAndDescription bo = new BOVProductAndDescription();
			bo.SetProperties("A", "A", "A", 1, "A");
			List<ApiVProductAndDescriptionResponseModel> response = mapper.MapBOToModel(new List<BOVProductAndDescription>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>db3d2dd88f2e6d9d854bc9a43183f60b</Hash>
</Codenesium>*/