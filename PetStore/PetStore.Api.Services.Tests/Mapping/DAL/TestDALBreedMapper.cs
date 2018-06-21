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
    <Hash>9ed2db1c2ab2f5c93826ef7787a2db52</Hash>
</Codenesium>*/