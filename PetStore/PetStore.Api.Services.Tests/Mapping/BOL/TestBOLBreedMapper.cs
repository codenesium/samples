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
        [Trait("Table", "Breed")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLBreedActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLBreedMapper();

                        ApiBreedRequestModel model = new ApiBreedRequestModel();

                        model.SetProperties("A");
                        BOBreed response = mapper.MapModelToBO(1, model);

                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLBreedMapper();

                        BOBreed bo = new BOBreed();

                        bo.SetProperties(1, "A");
                        ApiBreedResponseModel response = mapper.MapBOToModel(bo);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLBreedMapper();

                        BOBreed bo = new BOBreed();

                        bo.SetProperties(1, "A");
                        List<ApiBreedResponseModel> response = mapper.MapBOToModel(new List<BOBreed>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>daef3c774f7eadf4f3e4e4000acc9d8e</Hash>
</Codenesium>*/