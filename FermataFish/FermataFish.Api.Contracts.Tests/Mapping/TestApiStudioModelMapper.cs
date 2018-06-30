using FermataFishNS.Api.Contracts;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FermataFishNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Studio")]
        [Trait("Area", "ApiModel")]
        public class TestApiStudioModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiStudioModelMapper();
                        var model = new ApiStudioRequestModel();
                        model.SetProperties("A", "A", "A", "A", 1, "A", "A");
                        ApiStudioResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Address1.Should().Be("A");
                        response.Address2.Should().Be("A");
                        response.City.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.StateId.Should().Be(1);
                        response.Website.Should().Be("A");
                        response.Zip.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiStudioModelMapper();
                        var model = new ApiStudioResponseModel();
                        model.SetProperties(1, "A", "A", "A", "A", 1, "A", "A");
                        ApiStudioRequestModel response = mapper.MapResponseToRequest(model);

                        response.Address1.Should().Be("A");
                        response.Address2.Should().Be("A");
                        response.City.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.StateId.Should().Be(1);
                        response.Website.Should().Be("A");
                        response.Zip.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>2ae120ea7eba1e17e1ce73dde47f8593</Hash>
</Codenesium>*/