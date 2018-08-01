using FluentAssertions;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Breed")]
	[Trait("Area", "DALMapper")]
	public class TestDALBreedMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALBreedMapper();
			var bo = new BOBreed();
			bo.SetProperties(1, "A", 1);

			Breed response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.SpeciesId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALBreedMapper();
			Breed entity = new Breed();
			entity.SetProperties(1, "A", 1);

			BOBreed response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.SpeciesId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALBreedMapper();
			Breed entity = new Breed();
			entity.SetProperties(1, "A", 1);

			List<BOBreed> response = mapper.MapEFToBO(new List<Breed>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>5ad517324fced6359089675ef988519b</Hash>
</Codenesium>*/