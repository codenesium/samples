using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ProductPhoto")]
	[Trait("Area", "DALMapper")]
	public class TestDALProductPhotoMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALProductPhotoMapper();
			ApiProductPhotoServerRequestModel model = new ApiProductPhotoServerRequestModel();
			model.SetProperties(BitConverter.GetBytes(1), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), BitConverter.GetBytes(1), "A");
			ProductPhoto response = mapper.MapModelToEntity(1, model);

			response.LargePhoto.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.LargePhotoFileName.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ThumbNailPhoto.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.ThumbnailPhotoFileName.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALProductPhotoMapper();
			ProductPhoto item = new ProductPhoto();
			item.SetProperties(1, BitConverter.GetBytes(1), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), BitConverter.GetBytes(1), "A");
			ApiProductPhotoServerResponseModel response = mapper.MapEntityToModel(item);

			response.LargePhoto.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.LargePhotoFileName.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ProductPhotoID.Should().Be(1);
			response.ThumbNailPhoto.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.ThumbnailPhotoFileName.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALProductPhotoMapper();
			ProductPhoto item = new ProductPhoto();
			item.SetProperties(1, BitConverter.GetBytes(1), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), BitConverter.GetBytes(1), "A");
			List<ApiProductPhotoServerResponseModel> response = mapper.MapEntityToModel(new List<ProductPhoto>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>ea4f14ed1fdf830377df860c567add5a</Hash>
</Codenesium>*/