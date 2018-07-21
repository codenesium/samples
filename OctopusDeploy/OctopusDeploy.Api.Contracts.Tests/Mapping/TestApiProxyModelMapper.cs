using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Proxy")]
        [Trait("Area", "ApiModel")]
        public class TestApiProxyModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiProxyModelMapper();
                        var model = new ApiProxyRequestModel();
                        model.SetProperties("A", "A");
                        ApiProxyResponseModel response = mapper.MapRequestToResponse("A", model);

                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiProxyModelMapper();
                        var model = new ApiProxyResponseModel();
                        model.SetProperties("A", "A", "A");
                        ApiProxyRequestModel response = mapper.MapResponseToRequest(model);

                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiProxyModelMapper();
                        var model = new ApiProxyRequestModel();
                        model.SetProperties("A", "A");

                        JsonPatchDocument<ApiProxyRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiProxyRequestModel();
                        patch.ApplyTo(response);

                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>ba7af93eb3b90344a1ea1c5d5a8fb40e</Hash>
</Codenesium>*/