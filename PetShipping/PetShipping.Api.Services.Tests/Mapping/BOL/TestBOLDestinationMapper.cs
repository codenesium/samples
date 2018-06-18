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
        [Trait("Table", "Destination")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLDestinationActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLDestinationMapper();

                        ApiDestinationRequestModel model = new ApiDestinationRequestModel();

                        model.SetProperties(1, "A", 1);
                        BODestination response = mapper.MapModelToBO(1, model);

                        response.CountryId.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.Order.Should().Be(1);
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLDestinationMapper();

                        BODestination bo = new BODestination();

                        bo.SetProperties(1, 1, "A", 1);
                        ApiDestinationResponseModel response = mapper.MapBOToModel(bo);

                        response.CountryId.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.Order.Should().Be(1);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLDestinationMapper();

                        BODestination bo = new BODestination();

                        bo.SetProperties(1, 1, "A", 1);
                        List<ApiDestinationResponseModel> response = mapper.MapBOToModel(new List<BODestination>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>aef33f8ee2a7b77701e12a45e022fb31</Hash>
</Codenesium>*/