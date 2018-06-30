using FluentAssertions;
using PetStoreNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetStoreNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Pen")]
        [Trait("Area", "ApiModel")]
        public class TestApiPenModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiPenModelMapper();
                        var model = new ApiPenRequestModel();
                        model.SetProperties("A");
                        ApiPenResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiPenModelMapper();
                        var model = new ApiPenResponseModel();
                        model.SetProperties(1, "A");
                        ApiPenRequestModel response = mapper.MapResponseToRequest(model);

                        response.Name.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>2fca01040a40e6e23968fb094bd6e042</Hash>
</Codenesium>*/