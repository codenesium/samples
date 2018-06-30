using FluentAssertions;
using PetStoreNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetStoreNS.Api.Contracts.Tests
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
    <Hash>f1956d8c9d2605ec635ebadf464271f4</Hash>
</Codenesium>*/