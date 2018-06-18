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
        [Trait("Table", "Pet")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLPetActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLPetMapper();

                        ApiPetRequestModel model = new ApiPetRequestModel();

                        model.SetProperties(1, 1, "A", 1);
                        BOPet response = mapper.MapModelToBO(1, model);

                        response.BreedId.Should().Be(1);
                        response.ClientId.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.Weight.Should().Be(1);
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLPetMapper();

                        BOPet bo = new BOPet();

                        bo.SetProperties(1, 1, 1, "A", 1);
                        ApiPetResponseModel response = mapper.MapBOToModel(bo);

                        response.BreedId.Should().Be(1);
                        response.ClientId.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.Weight.Should().Be(1);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLPetMapper();

                        BOPet bo = new BOPet();

                        bo.SetProperties(1, 1, 1, "A", 1);
                        List<ApiPetResponseModel> response = mapper.MapBOToModel(new List<BOPet>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>1220fbe2a2aaed6dd62fe93189f290e0</Hash>
</Codenesium>*/