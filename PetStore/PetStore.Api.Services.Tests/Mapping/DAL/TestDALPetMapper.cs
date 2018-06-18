using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using PetStoreNS.Api.DataAccess;
using PetStoreNS.Api.Services;

namespace PetStoreNS.Api.Services.Tests
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

                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1, 1, 1);

                        Pet response = mapper.MapBOToEF(bo);

                        response.AcquiredDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.BreedId.Should().Be(1);
                        response.Description.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.PenId.Should().Be(1);
                        response.Price.Should().Be(1);
                        response.SpeciesId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALPetMapper();

                        Pet entity = new Pet();

                        entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1, 1, 1, 1);

                        BOPet  response = mapper.MapEFToBO(entity);

                        response.AcquiredDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.BreedId.Should().Be(1);
                        response.Description.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.PenId.Should().Be(1);
                        response.Price.Should().Be(1);
                        response.SpeciesId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALPetMapper();

                        Pet entity = new Pet();

                        entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1, 1, 1, 1);

                        List<BOPet> response = mapper.MapEFToBO(new List<Pet>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>3f6c19568a235724d884073fecf822c9</Hash>
</Codenesium>*/