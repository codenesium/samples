using FluentAssertions;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Channel")]
        [Trait("Area", "ApiModel")]
        public class TestApiChannelModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiChannelModelMapper();
                        var model = new ApiChannelRequestModel();
                        model.SetProperties(BitConverter.GetBytes(1), "A", "A", "A", "A", "A");
                        ApiChannelResponseModel response = mapper.MapRequestToResponse("A", model);

                        response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.LifecycleId.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.ProjectId.Should().Be("A");
                        response.TenantTags.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiChannelModelMapper();
                        var model = new ApiChannelResponseModel();
                        model.SetProperties("A", BitConverter.GetBytes(1), "A", "A", "A", "A", "A");
                        ApiChannelRequestModel response = mapper.MapResponseToRequest(model);

                        response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
                        response.JSON.Should().Be("A");
                        response.LifecycleId.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.ProjectId.Should().Be("A");
                        response.TenantTags.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>a968c35698a2c330ffa8e74e3c599baf</Hash>
</Codenesium>*/