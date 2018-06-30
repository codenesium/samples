using FluentAssertions;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ActionTemplateVersion")]
        [Trait("Area", "ApiModel")]
        public class TestApiActionTemplateVersionModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiActionTemplateVersionModelMapper();
                        var model = new ApiActionTemplateVersionRequestModel();
                        model.SetProperties("A", "A", "A", "A", 1);
                        ApiActionTemplateVersionResponseModel response = mapper.MapRequestToResponse("A", model);

                        response.ActionType.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.LatestActionTemplateId.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.Version.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiActionTemplateVersionModelMapper();
                        var model = new ApiActionTemplateVersionResponseModel();
                        model.SetProperties("A", "A", "A", "A", "A", 1);
                        ApiActionTemplateVersionRequestModel response = mapper.MapResponseToRequest(model);

                        response.ActionType.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.LatestActionTemplateId.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.Version.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>08930d2cdbed24c59a4ebb28f5197f73</Hash>
</Codenesium>*/