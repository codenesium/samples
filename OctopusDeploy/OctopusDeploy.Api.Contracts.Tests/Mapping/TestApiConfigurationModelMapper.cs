using FluentAssertions;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Configuration")]
        [Trait("Area", "ApiModel")]
        public class TestApiConfigurationModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiConfigurationModelMapper();
                        var model = new ApiConfigurationRequestModel();
                        model.SetProperties("A");
                        ApiConfigurationResponseModel response = mapper.MapRequestToResponse("A", model);

                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiConfigurationModelMapper();
                        var model = new ApiConfigurationResponseModel();
                        model.SetProperties("A", "A");
                        ApiConfigurationRequestModel response = mapper.MapResponseToRequest(model);

                        response.JSON.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>410fdc12e782f279c1b68e039047987d</Hash>
</Codenesium>*/