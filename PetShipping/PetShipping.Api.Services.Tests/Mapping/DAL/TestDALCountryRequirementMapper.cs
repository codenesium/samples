using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;

namespace PetShippingNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "CountryRequirement")]
        [Trait("Area", "DALMapper")]
        public class TestDALCountryRequirementActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALCountryRequirementMapper();

                        var bo = new BOCountryRequirement();

                        bo.SetProperties(1, 1, "A");

                        CountryRequirement response = mapper.MapBOToEF(bo);

                        response.CountryId.Should().Be(1);
                        response.Details.Should().Be("A");
                        response.Id.Should().Be(1);
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALCountryRequirementMapper();

                        CountryRequirement entity = new CountryRequirement();

                        entity.SetProperties(1, "A", 1);

                        BOCountryRequirement  response = mapper.MapEFToBO(entity);

                        response.CountryId.Should().Be(1);
                        response.Details.Should().Be("A");
                        response.Id.Should().Be(1);
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALCountryRequirementMapper();

                        CountryRequirement entity = new CountryRequirement();

                        entity.SetProperties(1, "A", 1);

                        List<BOCountryRequirement> response = mapper.MapEFToBO(new List<CountryRequirement>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>2b40416d9106d1e70e70b42d1cefa647</Hash>
</Codenesium>*/