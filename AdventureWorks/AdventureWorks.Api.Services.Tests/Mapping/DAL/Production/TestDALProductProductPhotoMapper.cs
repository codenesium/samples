using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ProductProductPhoto")]
	[Trait("Area", "DALMapper")]
	public class TestDALProductProductPhotoMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALProductProductPhotoMapper();
			var bo = new BOProductProductPhoto();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), true, 1);

			ProductProductPhoto response = mapper.MapBOToEF(bo);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Primary.Should().Be(true);
			response.ProductID.Should().Be(1);
			response.ProductPhotoID.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALProductProductPhotoMapper();
			ProductProductPhoto entity = new ProductProductPhoto();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), true, 1, 1);

			BOProductProductPhoto response = mapper.MapEFToBO(entity);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Primary.Should().Be(true);
			response.ProductID.Should().Be(1);
			response.ProductPhotoID.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALProductProductPhotoMapper();
			ProductProductPhoto entity = new ProductProductPhoto();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), true, 1, 1);

			List<BOProductProductPhoto> response = mapper.MapEFToBO(new List<ProductProductPhoto>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>a29b2754c919b78e87d6b4c637ce5c34</Hash>
</Codenesium>*/