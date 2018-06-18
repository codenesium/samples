using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;

namespace PetShippingNS.Api.Services.Tests
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
    <Hash>02a75d35827c00411476d716d8912fa7</Hash>
</Codenesium>*/