using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ProductModelProductDescriptionCulture")]
	[Trait("Area", "DALMapper")]
	public class TestDALProductModelProductDescriptionCultureMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALProductModelProductDescriptionCultureMapper();
			var bo = new BOProductModelProductDescriptionCulture();
			bo.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1);

			ProductModelProductDescriptionCulture response = mapper.MapBOToEF(bo);

			response.CultureID.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ProductDescriptionID.Should().Be(1);
			response.ProductModelID.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALProductModelProductDescriptionCultureMapper();
			ProductModelProductDescriptionCulture entity = new ProductModelProductDescriptionCulture();
			entity.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1);

			BOProductModelProductDescriptionCulture response = mapper.MapEFToBO(entity);

			response.CultureID.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ProductDescriptionID.Should().Be(1);
			response.ProductModelID.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALProductModelProductDescriptionCultureMapper();
			ProductModelProductDescriptionCulture entity = new ProductModelProductDescriptionCulture();
			entity.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1);

			List<BOProductModelProductDescriptionCulture> response = mapper.MapEFToBO(new List<ProductModelProductDescriptionCulture>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>187ac513cce6bf3a1bd94b6b78391abe</Hash>
</Codenesium>*/