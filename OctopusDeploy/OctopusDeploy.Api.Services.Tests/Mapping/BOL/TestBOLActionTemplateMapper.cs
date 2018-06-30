using FluentAssertions;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ActionTemplate")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLActionTemplateMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLActionTemplateMapper();
                        ApiActionTemplateRequestModel model = new ApiActionTemplateRequestModel();
                        model.SetProperties("A", "A", "A", "A", 1);
                        BOActionTemplate response = mapper.MapModelToBO("A", model);

                        response.ActionType.Should().Be("A");
                        response.CommunityActionTemplateId.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.Version.Should().Be(1);
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLActionTemplateMapper();
                        BOActionTemplate bo = new BOActionTemplate();
                        bo.SetProperties("A", "A", "A", "A", "A", 1);
                        ApiActionTemplateResponseModel response = mapper.MapBOToModel(bo);

                        response.ActionType.Should().Be("A");
                        response.CommunityActionTemplateId.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.Version.Should().Be(1);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLActionTemplateMapper();
                        BOActionTemplate bo = new BOActionTemplate();
                        bo.SetProperties("A", "A", "A", "A", "A", 1);
                        List<ApiActionTemplateResponseModel> response = mapper.MapBOToModel(new List<BOActionTemplate>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>fbca87d6a93793de58d019d3f27c5f0f</Hash>
</Codenesium>*/