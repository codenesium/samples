using FluentAssertions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "CountryRequirement")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLCountryRequirementMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLCountryRequirementMapper();
                        ApiCountryRequirementRequestModel model = new ApiCountryRequirementRequestModel();
                        model.SetProperties(1, "A");
                        BOCountryRequirement response = mapper.MapModelToBO(1, model);

                        response.CountryId.Should().Be(1);
                        response.Details.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLCountryRequirementMapper();
                        BOCountryRequirement bo = new BOCountryRequirement();
                        bo.SetProperties(1, 1, "A");
                        ApiCountryRequirementResponseModel response = mapper.MapBOToModel(bo);

                        response.CountryId.Should().Be(1);
                        response.Details.Should().Be("A");
                        response.Id.Should().Be(1);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLCountryRequirementMapper();
                        BOCountryRequirement bo = new BOCountryRequirement();
                        bo.SetProperties(1, 1, "A");
                        List<ApiCountryRequirementResponseModel> response = mapper.MapBOToModel(new List<BOCountryRequirement>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>d4533820d66fec2762f9ed034bac3dba</Hash>
</Codenesium>*/