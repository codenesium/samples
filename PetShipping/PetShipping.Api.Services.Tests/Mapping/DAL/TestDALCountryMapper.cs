using FluentAssertions;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Country")]
        [Trait("Area", "DALMapper")]
        public class TestDALCountryMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALCountryMapper();
                        var bo = new BOCountry();
                        bo.SetProperties(1, "A");

                        Country response = mapper.MapBOToEF(bo);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALCountryMapper();
                        Country entity = new Country();
                        entity.SetProperties(1, "A");

                        BOCountry response = mapper.MapEFToBO(entity);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALCountryMapper();
                        Country entity = new Country();
                        entity.SetProperties(1, "A");

                        List<BOCountry> response = mapper.MapEFToBO(new List<Country>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>893dd9e87d52a6b5e49eb4b030f8962e</Hash>
</Codenesium>*/