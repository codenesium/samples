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
	[Trait("Area", "DALMapper")]
	public class TestDALVProductAndDescriptionMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALVProductAndDescriptionMapper();
			var bo = new BOVProductAndDescription();
			bo.SetProperties("A", "A", "A", 1, "A");

			VProductAndDescription response = mapper.MapBOToEF(bo);

			response.CultureID.Should().Be("A");
			response.Description.Should().Be("A");
			response.Name.Should().Be("A");
			response.ProductID.Should().Be(1);
			response.ProductModel.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALVProductAndDescriptionMapper();
			VProductAndDescription entity = new VProductAndDescription();
			entity.SetProperties("A", "A", "A", 1, "A");

			BOVProductAndDescription response = mapper.MapEFToBO(entity);

			response.CultureID.Should().Be("A");
			response.Description.Should().Be("A");
			response.Name.Should().Be("A");
			response.ProductID.Should().Be(1);
			response.ProductModel.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALVProductAndDescriptionMapper();
			VProductAndDescription entity = new VProductAndDescription();
			entity.SetProperties("A", "A", "A", 1, "A");

			List<BOVProductAndDescription> response = mapper.MapEFToBO(new List<VProductAndDescription>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>83f73492c5e896c8a4be8748419beb7a</Hash>
</Codenesium>*/