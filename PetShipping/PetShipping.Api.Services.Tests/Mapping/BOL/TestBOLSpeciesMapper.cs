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
        [Trait("Table", "Species")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLSpeciesActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLSpeciesMapper();

                        ApiSpeciesRequestModel model = new ApiSpeciesRequestModel();

                        model.SetProperties("A");
                        BOSpecies response = mapper.MapModelToBO(1, model);

                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLSpeciesMapper();

                        BOSpecies bo = new BOSpecies();

                        bo.SetProperties(1, "A");
                        ApiSpeciesResponseModel response = mapper.MapBOToModel(bo);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLSpeciesMapper();

                        BOSpecies bo = new BOSpecies();

                        bo.SetProperties(1, "A");
                        List<ApiSpeciesResponseModel> response = mapper.MapBOToModel(new List<BOSpecies>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>a2cdec8dff77d19464c64a5cefb22a05</Hash>
</Codenesium>*/