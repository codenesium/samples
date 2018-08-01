using FluentAssertions;
using PetStoreNS.Api.DataAccess;
using PetStoreNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetStoreNS.Api.Services.Tests
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
			bo.SetProperties(1, "A");

			Breed response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALBreedMapper();
			Breed entity = new Breed();
			entity.SetProperties(1, "A");

			BOBreed response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALBreedMapper();
			Breed entity = new Breed();
			entity.SetProperties(1, "A");

			List<BOBreed> response = mapper.MapEFToBO(new List<Breed>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>f96ca843c738d86afbf821a64cb7a443</Hash>
</Codenesium>*/