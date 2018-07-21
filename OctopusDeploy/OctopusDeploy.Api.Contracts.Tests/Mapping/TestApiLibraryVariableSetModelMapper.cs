using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
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

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiLibraryVariableSetModelMapper();
                        var model = new ApiLibraryVariableSetRequestModel();
                        model.SetProperties("A", "A", "A", "A");

                        JsonPatchDocument<ApiLibraryVariableSetRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiLibraryVariableSetRequestModel();
                        patch.ApplyTo(response);

                        response.ContentType.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.VariableSetId.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>c27531d3a22ee475a08432aca751b687</Hash>
</Codenesium>*/