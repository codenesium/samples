using FluentAssertions;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ExtensionConfiguration")]
        [Trait("Area", "ApiModel")]
        public class TestApiExtensionConfigurationModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiExtensionConfigurationModelMapper();
                        var model = new ApiExtensionConfigurationRequestModel();
                        model.SetProperties("A", "A", "A");
                        ApiExtensionConfigurationResponseModel response = mapper.MapRequestToResponse("A", model);

                        response.ExtensionAuthor.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiExtensionConfigurationModelMapper();
                        var model = new ApiExtensionConfigurationResponseModel();
                        model.SetProperties("A", "A", "A", "A");
                        ApiExtensionConfigurationRequestModel response = mapper.MapResponseToRequest(model);

                        response.ExtensionAuthor.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>c438ebfe1c3bd77b8c9dfcc7e314f127</Hash>
</Codenesium>*/