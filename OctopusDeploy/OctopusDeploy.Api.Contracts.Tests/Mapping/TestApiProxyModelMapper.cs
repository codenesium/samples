using FluentAssertions;
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
        }
}

/*<Codenesium>
    <Hash>4ef5d2d05544468bdc67e881dab166dd</Hash>
</Codenesium>*/