using FluentAssertions;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "LibraryVariableSet")]
        [Trait("Area", "ApiModel")]
        public class TestApiLibraryVariableSetModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiLibraryVariableSetModelMapper();
                        var model = new ApiLibraryVariableSetRequestModel();
                        model.SetProperties("A", "A", "A", "A");
                        ApiLibraryVariableSetResponseModel response = mapper.MapRequestToResponse("A", model);

                        response.ContentType.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.VariableSetId.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiLibraryVariableSetModelMapper();
                        var model = new ApiLibraryVariableSetResponseModel();
                        model.SetProperties("A", "A", "A", "A", "A");
                        ApiLibraryVariableSetRequestModel response = mapper.MapResponseToRequest(model);

                        response.ContentType.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.VariableSetId.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>69e2f0dc903a44703b2ddb0a80965adc</Hash>
</Codenesium>*/