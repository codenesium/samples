using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Artifact")]
        [Trait("Area", "DALMapper")]
        public class TestDALArtifactActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALArtifactMapper();

                        var bo = new BOArtifact();

                        bo.SetProperties("A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", "A");

                        Artifact response = mapper.MapBOToEF(bo);

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
                public void MapEFToBO()
                {
                        var mapper = new DALArtifactMapper();

                        Artifact entity = new Artifact();

                        entity.SetProperties(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", "A", "A");

                        BOArtifact  response = mapper.MapEFToBO(entity);

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
                public void MapEFToBOList()
                {
                        var mapper = new DALArtifactMapper();

                        Artifact entity = new Artifact();

                        entity.SetProperties(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", "A", "A");

                        List<BOArtifact> response = mapper.MapEFToBO(new List<Artifact>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>cc37b5307e05c3844414e0e093cc1188</Hash>
</Codenesium>*/