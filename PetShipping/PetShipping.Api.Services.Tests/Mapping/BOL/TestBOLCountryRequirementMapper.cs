using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;

namespace PetShippingNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "CountryRequirement")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLCountryRequirementActionMapper
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
    <Hash>a21ebe603e626b542d251e8ef9efcd5e</Hash>
</Codenesium>*/