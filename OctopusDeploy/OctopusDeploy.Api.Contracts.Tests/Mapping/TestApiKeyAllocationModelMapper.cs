using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "KeyAllocation")]
        [Trait("Area", "ApiModel")]
        public class TestApiKeyAllocationModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiKeyAllocationModelMapper();
                        var model = new ApiKeyAllocationRequestModel();
                        model.SetProperties(1);
                        ApiKeyAllocationResponseModel response = mapper.MapRequestToResponse("A", model);

                        response.Allocated.Should().Be(1);
                        response.CollectionName.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiKeyAllocationModelMapper();
                        var model = new ApiKeyAllocationResponseModel();
                        model.SetProperties("A", 1);
                        ApiKeyAllocationRequestModel response = mapper.MapResponseToRequest(model);

                        response.Allocated.Should().Be(1);
                }

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiKeyAllocationModelMapper();
                        var model = new ApiKeyAllocationRequestModel();
                        model.SetProperties(1);

                        JsonPatchDocument<ApiKeyAllocationRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiKeyAllocationRequestModel();
                        patch.ApplyTo(response);

                        response.Allocated.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>bced7aa9e8f719ec14554d21a808dd99</Hash>
</Codenesium>*/