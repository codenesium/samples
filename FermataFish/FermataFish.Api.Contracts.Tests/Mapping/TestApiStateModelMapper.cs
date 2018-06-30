using FermataFishNS.Api.Contracts;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FermataFishNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "State")]
        [Trait("Area", "ApiModel")]
        public class TestApiStateModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiStateModelMapper();
                        var model = new ApiStateRequestModel();
                        model.SetProperties("A");
                        ApiStateResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiStateModelMapper();
                        var model = new ApiStateResponseModel();
                        model.SetProperties(1, "A");
                        ApiStateRequestModel response = mapper.MapResponseToRequest(model);

                        response.Name.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>676b2cf77008c4e87062a73cdb9a723c</Hash>
</Codenesium>*/