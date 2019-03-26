using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ProductProductPhoto")]
	[Trait("Area", "DALMapper")]
	public class TestDALProductProductPhotoMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALProductProductPhotoMapper();
			ApiProductProductPhotoServerRequestModel model = new ApiProductProductPhotoServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), true, 1);
			ProductProductPhoto response = mapper.MapModelToEntity(1, model);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Primary.Should().Be(true);
			response.ProductPhotoID.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALProductProductPhotoMapper();
			ProductProductPhoto item = new ProductProductPhoto();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), true, 1);
			ApiProductProductPhotoServerResponseModel response = mapper.MapEntityToModel(item);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Primary.Should().Be(true);
			response.ProductID.Should().Be(1);
			response.ProductPhotoID.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALProductProductPhotoMapper();
			ProductProductPhoto item = new ProductProductPhoto();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), true, 1);
			List<ApiProductProductPhotoServerResponseModel> response = mapper.MapEntityToModel(new List<ProductProductPhoto>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>01db63658e441111a074a6481a77a3c9</Hash>
</Codenesium>*/