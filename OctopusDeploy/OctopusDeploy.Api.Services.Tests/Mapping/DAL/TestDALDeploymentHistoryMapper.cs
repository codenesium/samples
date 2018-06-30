using FluentAssertions;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "DeploymentHistory")]
        [Trait("Area", "DALMapper")]
        public class TestDALDeploymentHistoryMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALDeploymentHistoryMapper();
                        var bo = new BODeploymentHistory();
                        bo.SetProperties("A", "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1, "A", "A", "A", "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A");

                        DeploymentHistory response = mapper.MapBOToEF(bo);

                        response.ChannelId.Should().Be("A");
                        response.ChannelName.Should().Be("A");
                        response.CompletedTime.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.Created.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.DeployedBy.Should().Be("A");
                        response.DeploymentId.Should().Be("A");
                        response.DeploymentName.Should().Be("A");
                        response.DurationSeconds.Should().Be(1);
                        response.EnvironmentId.Should().Be("A");
                        response.EnvironmentName.Should().Be("A");
                        response.ProjectId.Should().Be("A");
                        response.ProjectName.Should().Be("A");
                        response.ProjectSlug.Should().Be("A");
                        response.QueueTime.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.ReleaseId.Should().Be("A");
                        response.ReleaseVersion.Should().Be("A");
                        response.StartTime.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.TaskId.Should().Be("A");
                        response.TaskState.Should().Be("A");
                        response.TenantId.Should().Be("A");
                        response.TenantName.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALDeploymentHistoryMapper();
                        DeploymentHistory entity = new DeploymentHistory();
                        entity.SetProperties("A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", 1, "A", "A", "A", "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A");

                        BODeploymentHistory response = mapper.MapEFToBO(entity);

                        response.ChannelId.Should().Be("A");
                        response.ChannelName.Should().Be("A");
                        response.CompletedTime.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.Created.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.DeployedBy.Should().Be("A");
                        response.DeploymentId.Should().Be("A");
                        response.DeploymentName.Should().Be("A");
                        response.DurationSeconds.Should().Be(1);
                        response.EnvironmentId.Should().Be("A");
                        response.EnvironmentName.Should().Be("A");
                        response.ProjectId.Should().Be("A");
                        response.ProjectName.Should().Be("A");
                        response.ProjectSlug.Should().Be("A");
                        response.QueueTime.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.ReleaseId.Should().Be("A");
                        response.ReleaseVersion.Should().Be("A");
                        response.StartTime.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.TaskId.Should().Be("A");
                        response.TaskState.Should().Be("A");
                        response.TenantId.Should().Be("A");
                        response.TenantName.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALDeploymentHistoryMapper();
                        DeploymentHistory entity = new DeploymentHistory();
                        entity.SetProperties("A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", 1, "A", "A", "A", "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A");

                        List<BODeploymentHistory> response = mapper.MapEFToBO(new List<DeploymentHistory>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>0a0bab3d48f067b6212be0dedf67e2e9</Hash>
</Codenesium>*/