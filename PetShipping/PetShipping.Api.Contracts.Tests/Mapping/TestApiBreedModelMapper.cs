using FluentAssertions;
using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Breed")]
        [Trait("Area", "ApiModel")]
        public class TestApiBreedModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiBreedModelMapper();
                        var model = new ApiBreedRequestModel();
                        model.SetProperties("A", 1);
                        ApiBreedResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.SpeciesId.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiBreedModelMapper();
                        var model = new ApiBreedResponseModel();
                        model.SetProperties(1, "A", 1);
                        ApiBreedRequestModel response = mapper.MapResponseToRequest(model);

                        response.Name.Should().Be("A");
                        response.SpeciesId.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>bbe7a0be970a83f9ea88bd6346e20fab</Hash>
</Codenesium>*/