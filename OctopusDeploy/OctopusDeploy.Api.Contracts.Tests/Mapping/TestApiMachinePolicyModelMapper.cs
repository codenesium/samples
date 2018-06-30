using FluentAssertions;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "MachinePolicy")]
        [Trait("Area", "ApiModel")]
        public class TestApiMachinePolicyModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiMachinePolicyModelMapper();
                        var model = new ApiMachinePolicyRequestModel();
                        model.SetProperties(true, "A", "A");
                        ApiMachinePolicyResponseModel response = mapper.MapRequestToResponse("A", model);

                        response.Id.Should().Be("A");
                        response.IsDefault.Should().Be(true);
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiMachinePolicyModelMapper();
                        var model = new ApiMachinePolicyResponseModel();
                        model.SetProperties("A", true, "A", "A");
                        ApiMachinePolicyRequestModel response = mapper.MapResponseToRequest(model);

                        response.IsDefault.Should().Be(true);
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>82cc3240a9be951c2b1549a86b70892e</Hash>
</Codenesium>*/