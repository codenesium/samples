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
        [Trait("Table", "Airline")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLAirlineActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLAirlineMapper();

                        ApiAirlineRequestModel model = new ApiAirlineRequestModel();

                        model.SetProperties("A");
                        BOAirline response = mapper.MapModelToBO(1, model);

                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLAirlineMapper();

                        BOAirline bo = new BOAirline();

                        bo.SetProperties(1, "A");
                        ApiAirlineResponseModel response = mapper.MapBOToModel(bo);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLAirlineMapper();

                        BOAirline bo = new BOAirline();

                        bo.SetProperties(1, "A");
                        List<ApiAirlineResponseModel> response = mapper.MapBOToModel(new List<BOAirline>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>eb1a33d8c51824f6058baab0d4de21a7</Hash>
</Codenesium>*/