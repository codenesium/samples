using FluentAssertions;
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
        }
}

/*<Codenesium>
    <Hash>e5bdc81eaab5d8d9f19c2e1b91b66f3a</Hash>
</Codenesium>*/