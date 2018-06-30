using FluentAssertions;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "TagSet")]
        [Trait("Area", "ApiModel")]
        public class TestApiTagSetModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiTagSetModelMapper();
                        var model = new ApiTagSetRequestModel();
                        model.SetProperties(BitConverter.GetBytes(1), "A", "A", 1);
                        ApiTagSetResponseModel response = mapper.MapRequestToResponse("A", model);

                        response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.SortOrder.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiTagSetModelMapper();
                        var model = new ApiTagSetResponseModel();
                        model.SetProperties("A", BitConverter.GetBytes(1), "A", "A", 1);
                        ApiTagSetRequestModel response = mapper.MapResponseToRequest(model);

                        response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.SortOrder.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>508b42a4e51ea98c4568f3b45781798f</Hash>
</Codenesium>*/