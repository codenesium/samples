using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using PetStoreNS.Api.DataAccess;
using PetStoreNS.Api.Services;

namespace PetStoreNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Breed")]
        [Trait("Area", "DALMapper")]
        public class TestDALBreedActionMapper
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

                        BOBreed  response = mapper.MapEFToBO(entity);

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
    <Hash>246646f004b8e4d78144fa9bb26f1a0e</Hash>
</Codenesium>*/