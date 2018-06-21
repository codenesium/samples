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
        [Trait("Table", "Country")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLCountryMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLCountryMapper();
                        ApiCountryRequestModel model = new ApiCountryRequestModel();
                        model.SetProperties("A");
                        BOCountry response = mapper.MapModelToBO(1, model);

                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLCountryMapper();
                        BOCountry bo = new BOCountry();
                        bo.SetProperties(1, "A");
                        ApiCountryResponseModel response = mapper.MapBOToModel(bo);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLCountryMapper();
                        BOCountry bo = new BOCountry();
                        bo.SetProperties(1, "A");
                        List<ApiCountryResponseModel> response = mapper.MapBOToModel(new List<BOCountry>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>8b199df74f5dea40057fba8bd3899907</Hash>
</Codenesium>*/