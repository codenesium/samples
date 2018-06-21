using FluentAssertions;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ServerTask")]
        [Trait("Area", "DALMapper")]
        public class TestDALServerTaskMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALServerTaskMapper();
                        var bo = new BOServerTask();
                        bo.SetProperties("A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1, "A", "A", true, true, "A", "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A");

                        ServerTask response = mapper.MapBOToEF(bo);

                        response.CompletedTime.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.ConcurrencyTag.Should().Be("A");
                        response.Description.Should().Be("A");
                        response.DurationSeconds.Should().Be(1);
                        response.EnvironmentId.Should().Be("A");
                        response.ErrorMessage.Should().Be("A");
                        response.HasPendingInterruptions.Should().Be(true);
                        response.HasWarningsOrErrors.Should().Be(true);
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.ProjectId.Should().Be("A");
                        response.QueueTime.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.ServerNodeId.Should().Be("A");
                        response.StartTime.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.State.Should().Be("A");
                        response.TenantId.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALServerTaskMapper();
                        ServerTask entity = new ServerTask();
                        entity.SetProperties(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1, "A", "A", true, true, "A", "A", "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A");

                        BOServerTask response = mapper.MapEFToBO(entity);

                        response.CompletedTime.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.ConcurrencyTag.Should().Be("A");
                        response.Description.Should().Be("A");
                        response.DurationSeconds.Should().Be(1);
                        response.EnvironmentId.Should().Be("A");
                        response.ErrorMessage.Should().Be("A");
                        response.HasPendingInterruptions.Should().Be(true);
                        response.HasWarningsOrErrors.Should().Be(true);
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.ProjectId.Should().Be("A");
                        response.QueueTime.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.ServerNodeId.Should().Be("A");
                        response.StartTime.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.State.Should().Be("A");
                        response.TenantId.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALServerTaskMapper();
                        ServerTask entity = new ServerTask();
                        entity.SetProperties(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1, "A", "A", true, true, "A", "A", "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A");

                        List<BOServerTask> response = mapper.MapEFToBO(new List<ServerTask>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>5551a12268a29facfc496170c27afe37</Hash>
</Codenesium>*/