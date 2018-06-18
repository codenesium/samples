using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "CommunityActionTemplate")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLCommunityActionTemplateActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLCommunityActionTemplateMapper();

                        ApiCommunityActionTemplateRequestModel model = new ApiCommunityActionTemplateRequestModel();

                        model.SetProperties(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", "A");
                        BOCommunityActionTemplate response = mapper.MapModelToBO("A", model);

                        response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLCommunityActionTemplateMapper();

                        BOCommunityActionTemplate bo = new BOCommunityActionTemplate();

                        bo.SetProperties("A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", "A");
                        ApiCommunityActionTemplateResponseModel response = mapper.MapBOToModel(bo);

                        response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLCommunityActionTemplateMapper();

                        BOCommunityActionTemplate bo = new BOCommunityActionTemplate();

                        bo.SetProperties("A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", "A");
                        List<ApiCommunityActionTemplateResponseModel> response = mapper.MapBOToModel(new List<BOCommunityActionTemplate>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>6efa66ff1f601d95907da5887ae4d3aa</Hash>
</Codenesium>*/