using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ProductPhoto")]
	[Trait("Area", "DALMapper")]
	public class TestDALProductPhotoMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALProductPhotoMapper();
			var bo = new BOProductPhoto();
			bo.SetProperties(1, BitConverter.GetBytes(1), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), BitConverter.GetBytes(1), "A");

			ProductPhoto response = mapper.MapBOToEF(bo);

			response.LargePhoto.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.LargePhotoFileName.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ProductPhotoID.Should().Be(1);
			response.ThumbNailPhoto.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.ThumbnailPhotoFileName.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALProductPhotoMapper();
			ProductPhoto entity = new ProductPhoto();
			entity.SetProperties(BitConverter.GetBytes(1), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, BitConverter.GetBytes(1), "A");

			BOProductPhoto response = mapper.MapEFToBO(entity);

			response.LargePhoto.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.LargePhotoFileName.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ProductPhotoID.Should().Be(1);
			response.ThumbNailPhoto.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.ThumbnailPhotoFileName.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALProductPhotoMapper();
			ProductPhoto entity = new ProductPhoto();
			entity.SetProperties(BitConverter.GetBytes(1), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, BitConverter.GetBytes(1), "A");

			List<BOProductPhoto> response = mapper.MapEFToBO(new List<ProductPhoto>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>8a1a7ac7b54cb727537db2af76b46529</Hash>
</Codenesium>*/