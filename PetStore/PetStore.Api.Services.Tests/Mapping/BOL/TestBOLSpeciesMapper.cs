using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using PetStoreNS.Api.Services;

namespace PetStoreNS.Api.Services.Tests
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
    <Hash>3db3a8b2bcd29bb3d851c76b690e7b55</Hash>
</Codenesium>*/