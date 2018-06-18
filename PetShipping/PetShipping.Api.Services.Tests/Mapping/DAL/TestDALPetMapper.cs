using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;

namespace PetShippingNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Pet")]
        [Trait("Area", "DALMapper")]
        public class TestDALPetActionMapper
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

                        BOPet  response = mapper.MapEFToBO(entity);

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
    <Hash>2f34cf8f9f5255c340a3aba1b4008960</Hash>
</Codenesium>*/