using FluentAssertions;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Pet")]
	[Trait("Area", "DALMapper")]
	public class TestDALPetMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALPetMapper();
			var bo = new BOPet();
			bo.SetProperties(1, 1, 1, "A", 1);

			Pet response = mapper.MapBOToEF(bo);

			response.BreedId.Should().Be(1);
			response.ClientId.Should().Be(1);
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.Weight.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALPetMapper();
			Pet entity = new Pet();
			entity.SetProperties(1, 1, 1, "A", 1);

			BOPet response = mapper.MapEFToBO(entity);

			response.BreedId.Should().Be(1);
			response.ClientId.Should().Be(1);
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.Weight.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALPetMapper();
			Pet entity = new Pet();
			entity.SetProperties(1, 1, 1, "A", 1);

			List<BOPet> response = mapper.MapEFToBO(new List<Pet>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>75bc6862bff40afd05d00f0c99281168</Hash>
</Codenesium>*/