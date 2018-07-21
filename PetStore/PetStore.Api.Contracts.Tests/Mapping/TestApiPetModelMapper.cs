using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using PetStoreNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetStoreNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Pet")]
        [Trait("Area", "ApiModel")]
        public class TestApiPetModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiPetModelMapper();
                        var model = new ApiPetRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1, 1m, 1);
                        ApiPetResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.AcquiredDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.BreedId.Should().Be(1);
                        response.Description.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.PenId.Should().Be(1);
                        response.Price.Should().Be(1m);
                        response.SpeciesId.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiPetModelMapper();
                        var model = new ApiPetResponseModel();
                        model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1, 1m, 1);
                        ApiPetRequestModel response = mapper.MapResponseToRequest(model);

                        response.AcquiredDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.BreedId.Should().Be(1);
                        response.Description.Should().Be("A");
                        response.PenId.Should().Be(1);
                        response.Price.Should().Be(1m);
                        response.SpeciesId.Should().Be(1);
                }

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiPetModelMapper();
                        var model = new ApiPetRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1, 1m, 1);

                        JsonPatchDocument<ApiPetRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiPetRequestModel();
                        patch.ApplyTo(response);

                        response.AcquiredDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.BreedId.Should().Be(1);
                        response.Description.Should().Be("A");
                        response.PenId.Should().Be(1);
                        response.Price.Should().Be(1m);
                        response.SpeciesId.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>173ebbe3d0061f9c15d0348320ab3578</Hash>
</Codenesium>*/