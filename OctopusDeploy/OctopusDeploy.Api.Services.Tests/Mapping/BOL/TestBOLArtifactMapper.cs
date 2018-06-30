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
        [Trait("Table", "Artifact")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLArtifactMapper
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
    <Hash>58f82ced519b49393eb822227e167ac9</Hash>
</Codenesium>*/