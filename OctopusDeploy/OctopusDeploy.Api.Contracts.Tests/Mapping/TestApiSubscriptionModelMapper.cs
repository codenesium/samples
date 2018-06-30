using FluentAssertions;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Subscription")]
        [Trait("Area", "ApiModel")]
        public class TestApiSubscriptionModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiSubscriptionModelMapper();
                        var model = new ApiSubscriptionRequestModel();
                        model.SetProperties(true, "A", "A", "A");
                        ApiSubscriptionResponseModel response = mapper.MapRequestToResponse("A", model);

                        response.Id.Should().Be("A");
                        response.IsDisabled.Should().Be(true);
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.Type.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiSubscriptionModelMapper();
                        var model = new ApiSubscriptionResponseModel();
                        model.SetProperties("A", true, "A", "A", "A");
                        ApiSubscriptionRequestModel response = mapper.MapResponseToRequest(model);

                        response.IsDisabled.Should().Be(true);
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.Type.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>bcf78a4a617ef703dba242e216f8a2cd</Hash>
</Codenesium>*/