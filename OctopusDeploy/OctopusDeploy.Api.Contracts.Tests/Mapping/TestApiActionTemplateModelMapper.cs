using FluentAssertions;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ActionTemplate")]
        [Trait("Area", "ApiModel")]
        public class TestApiActionTemplateModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiActionTemplateModelMapper();
                        var model = new ApiActionTemplateRequestModel();
                        model.SetProperties("A", "A", "A", "A", 1);
                        ApiActionTemplateResponseModel response = mapper.MapRequestToResponse("A", model);

                        response.ActionType.Should().Be("A");
                        response.CommunityActionTemplateId.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.Version.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiActionTemplateModelMapper();
                        var model = new ApiActionTemplateResponseModel();
                        model.SetProperties("A", "A", "A", "A", "A", 1);
                        ApiActionTemplateRequestModel response = mapper.MapResponseToRequest(model);

                        response.ActionType.Should().Be("A");
                        response.CommunityActionTemplateId.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.Version.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>1d22b8cb105acb792c9baed15ba1a523</Hash>
</Codenesium>*/