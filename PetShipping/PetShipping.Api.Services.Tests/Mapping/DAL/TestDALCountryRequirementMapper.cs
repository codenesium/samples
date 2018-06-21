using FluentAssertions;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "CountryRequirement")]
        [Trait("Area", "DALMapper")]
        public class TestDALCountryRequirementMapper
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

                        BOCountryRequirement response = mapper.MapEFToBO(entity);

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
    <Hash>5f3a4ba22e0c4cc1f6369ddc4d065e10</Hash>
</Codenesium>*/