using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Deployment")]
        [Trait("Area", "DALMapper")]
        public class TestDALDeploymentActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALDeploymentMapper();

                        var bo = new BODeployment();

                        bo.SetProperties("A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", "A", "A", "A", "A", "A");

                        Deployment response = mapper.MapBOToEF(bo);

                        response.ChannelId.Should().Be("A");
                        response.Created.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.DeployedBy.Should().Be("A");
                        response.DeployedToMachineIds.Should().Be("A");
                        response.EnvironmentId.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.ProjectGroupId.Should().Be("A");
                        response.ProjectId.Should().Be("A");
                        response.ReleaseId.Should().Be("A");
                        response.TaskId.Should().Be("A");
                        response.TenantId.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALDeploymentMapper();

                        Deployment entity = new Deployment();

                        entity.SetProperties("A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", "A", "A", "A", "A", "A", "A");

                        BODeployment  response = mapper.MapEFToBO(entity);

                        response.ChannelId.Should().Be("A");
                        response.Created.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.DeployedBy.Should().Be("A");
                        response.DeployedToMachineIds.Should().Be("A");
                        response.EnvironmentId.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.ProjectGroupId.Should().Be("A");
                        response.ProjectId.Should().Be("A");
                        response.ReleaseId.Should().Be("A");
                        response.TaskId.Should().Be("A");
                        response.TenantId.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALDeploymentMapper();

                        Deployment entity = new Deployment();

                        entity.SetProperties("A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", "A", "A", "A", "A", "A", "A");

                        List<BODeployment> response = mapper.MapEFToBO(new List<Deployment>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>2bf461503505559cc96cf997b9943f0b</Hash>
</Codenesium>*/