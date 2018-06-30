using FluentAssertions;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "CommunityActionTemplate")]
        [Trait("Area", "ApiModel")]
        public class TestApiCommunityActionTemplateModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiCommunityActionTemplateModelMapper();
                        var model = new ApiCommunityActionTemplateRequestModel();
                        model.SetProperties(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", "A");
                        ApiCommunityActionTemplateResponseModel response = mapper.MapRequestToResponse("A", model);

                        response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiCommunityActionTemplateModelMapper();
                        var model = new ApiCommunityActionTemplateResponseModel();
                        model.SetProperties("A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", "A");
                        ApiCommunityActionTemplateRequestModel response = mapper.MapResponseToRequest(model);

                        response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>c369e80b5b739de9583b165bd139bf4a</Hash>
</Codenesium>*/