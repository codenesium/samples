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
        [Trait("Table", "Artifact")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLArtifactActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLArtifactMapper();

                        ApiArtifactRequestModel model = new ApiArtifactRequestModel();

                        model.SetProperties(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", "A");
                        BOArtifact response = mapper.MapModelToBO("A", model);

                        response.Created.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.EnvironmentId.Should().Be("A");
                        response.Filename.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.ProjectId.Should().Be("A");
                        response.RelatedDocumentIds.Should().Be("A");
                        response.TenantId.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLArtifactMapper();

                        BOArtifact bo = new BOArtifact();

                        bo.SetProperties("A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", "A");
                        ApiArtifactResponseModel response = mapper.MapBOToModel(bo);

                        response.Created.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.EnvironmentId.Should().Be("A");
                        response.Filename.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.ProjectId.Should().Be("A");
                        response.RelatedDocumentIds.Should().Be("A");
                        response.TenantId.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLArtifactMapper();

                        BOArtifact bo = new BOArtifact();

                        bo.SetProperties("A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", "A");
                        List<ApiArtifactResponseModel> response = mapper.MapBOToModel(new List<BOArtifact>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>b17f1bc4ef00bf981f9aa1287e1b3989</Hash>
</Codenesium>*/