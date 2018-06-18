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
        [Trait("Table", "ActionTemplateVersion")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLActionTemplateVersionActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLActionTemplateVersionMapper();

                        ApiActionTemplateVersionRequestModel model = new ApiActionTemplateVersionRequestModel();

                        model.SetProperties("A", "A", "A", "A", 1);
                        BOActionTemplateVersion response = mapper.MapModelToBO("A", model);

                        response.ActionType.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.LatestActionTemplateId.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.Version.Should().Be(1);
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLActionTemplateVersionMapper();

                        BOActionTemplateVersion bo = new BOActionTemplateVersion();

                        bo.SetProperties("A", "A", "A", "A", "A", 1);
                        ApiActionTemplateVersionResponseModel response = mapper.MapBOToModel(bo);

                        response.ActionType.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.LatestActionTemplateId.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.Version.Should().Be(1);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLActionTemplateVersionMapper();

                        BOActionTemplateVersion bo = new BOActionTemplateVersion();

                        bo.SetProperties("A", "A", "A", "A", "A", 1);
                        List<ApiActionTemplateVersionResponseModel> response = mapper.MapBOToModel(new List<BOActionTemplateVersion>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>9570fe3ce7eede69ef2518f87c5a99c4</Hash>
</Codenesium>*/