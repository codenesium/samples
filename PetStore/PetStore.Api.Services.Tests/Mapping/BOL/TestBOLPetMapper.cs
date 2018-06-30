using FluentAssertions;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using PetStoreNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetStoreNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Pet")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLPetMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLPetMapper();
                        ApiPetRequestModel model = new ApiPetRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1, 1, 1);
                        BOPet response = mapper.MapModelToBO(1, model);

                        response.AcquiredDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.BreedId.Should().Be(1);
                        response.Description.Should().Be("A");
                        response.PenId.Should().Be(1);
                        response.Price.Should().Be(1);
                        response.SpeciesId.Should().Be(1);
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLPetMapper();
                        BOPet bo = new BOPet();
                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1, 1, 1);
                        ApiPetResponseModel response = mapper.MapBOToModel(bo);

                        response.AcquiredDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.BreedId.Should().Be(1);
                        response.Description.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.PenId.Should().Be(1);
                        response.Price.Should().Be(1);
                        response.SpeciesId.Should().Be(1);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLPetMapper();
                        BOPet bo = new BOPet();
                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1, 1, 1);
                        List<ApiPetResponseModel> response = mapper.MapBOToModel(new List<BOPet>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>990920de8d6a909bedbabff134e5a6c8</Hash>
</Codenesium>*/