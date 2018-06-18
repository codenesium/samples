using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using PetStoreNS.Api.DataAccess;
using PetStoreNS.Api.Services;

namespace PetStoreNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Species")]
        [Trait("Area", "DALMapper")]
        public class TestDALSpeciesActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALSpeciesMapper();

                        var bo = new BOSpecies();

                        bo.SetProperties(1, "A");

                        Species response = mapper.MapBOToEF(bo);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALSpeciesMapper();

                        Species entity = new Species();

                        entity.SetProperties(1, "A");

                        BOSpecies  response = mapper.MapEFToBO(entity);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALSpeciesMapper();

                        Species entity = new Species();

                        entity.SetProperties(1, "A");

                        List<BOSpecies> response = mapper.MapEFToBO(new List<Species>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>d88a6701a798374cd61b3aa6e26ddc12</Hash>
</Codenesium>*/