using FluentAssertions;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Release")]
        [Trait("Area", "DALMapper")]
        public class TestDALReleaseMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALReleaseMapper();
                        var bo = new BORelease();
                        bo.SetProperties("A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", "A");

                        Release response = mapper.MapBOToEF(bo);

                        response.Assembled.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.ChannelId.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.ProjectDeploymentProcessSnapshotId.Should().Be("A");
                        response.ProjectId.Should().Be("A");
                        response.ProjectVariableSetSnapshotId.Should().Be("A");
                        response.Version.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALReleaseMapper();
                        Release entity = new Release();
                        entity.SetProperties(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", "A", "A");

                        BORelease response = mapper.MapEFToBO(entity);

                        response.Assembled.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.ChannelId.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.ProjectDeploymentProcessSnapshotId.Should().Be("A");
                        response.ProjectId.Should().Be("A");
                        response.ProjectVariableSetSnapshotId.Should().Be("A");
                        response.Version.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALReleaseMapper();
                        Release entity = new Release();
                        entity.SetProperties(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", "A", "A");

                        List<BORelease> response = mapper.MapEFToBO(new List<Release>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>1e5af5cfa55b5ae74b80ed3d90784ddf</Hash>
</Codenesium>*/