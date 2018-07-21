using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "VariableSet")]
        [Trait("Area", "ApiModel")]
        public class TestApiVariableSetModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiVariableSetModelMapper();
                        var model = new ApiVariableSetRequestModel();
                        model.SetProperties(true, "A", "A", "A", 1);
                        ApiVariableSetResponseModel response = mapper.MapRequestToResponse("A", model);

                        response.Id.Should().Be("A");
                        response.IsFrozen.Should().Be(true);
                        response.JSON.Should().Be("A");
                        response.OwnerId.Should().Be("A");
                        response.RelatedDocumentIds.Should().Be("A");
                        response.Version.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiVariableSetModelMapper();
                        var model = new ApiVariableSetResponseModel();
                        model.SetProperties("A", true, "A", "A", "A", 1);
                        ApiVariableSetRequestModel response = mapper.MapResponseToRequest(model);

                        response.IsFrozen.Should().Be(true);
                        response.JSON.Should().Be("A");
                        response.OwnerId.Should().Be("A");
                        response.RelatedDocumentIds.Should().Be("A");
                        response.Version.Should().Be(1);
                }

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiVariableSetModelMapper();
                        var model = new ApiVariableSetRequestModel();
                        model.SetProperties(true, "A", "A", "A", 1);

                        JsonPatchDocument<ApiVariableSetRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiVariableSetRequestModel();
                        patch.ApplyTo(response);

                        response.IsFrozen.Should().Be(true);
                        response.JSON.Should().Be("A");
                        response.OwnerId.Should().Be("A");
                        response.RelatedDocumentIds.Should().Be("A");
                        response.Version.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>6d2e5928135b2e051b85966a8d74a7a3</Hash>
</Codenesium>*/