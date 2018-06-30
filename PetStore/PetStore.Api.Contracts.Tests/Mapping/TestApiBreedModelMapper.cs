using FluentAssertions;
using PetStoreNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetStoreNS.Api.Contracts.Tests
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
                        model.SetProperties("A");
                        ApiBreedResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiBreedModelMapper();
                        var model = new ApiBreedResponseModel();
                        model.SetProperties(1, "A");
                        ApiBreedRequestModel response = mapper.MapResponseToRequest(model);

                        response.Name.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>e7d93453d4061114b5f04ed3d8515f51</Hash>
</Codenesium>*/