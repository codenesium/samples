using FluentAssertions;
using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Species")]
        [Trait("Area", "ApiModel")]
        public class TestApiSpeciesModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiSpeciesModelMapper();
                        var model = new ApiSpeciesRequestModel();
                        model.SetProperties("A");
                        ApiSpeciesResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiSpeciesModelMapper();
                        var model = new ApiSpeciesResponseModel();
                        model.SetProperties(1, "A");
                        ApiSpeciesRequestModel response = mapper.MapResponseToRequest(model);

                        response.Name.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>5def9cc514f9ab9da0e6bd8b7a86c9ae</Hash>
</Codenesium>*/