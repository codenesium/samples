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
        [Trait("Table", "ServerTask")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLServerTaskMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLServerTaskMapper();
                        ApiServerTaskRequestModel model = new ApiServerTaskRequestModel();
                        model.SetProperties(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1, "A", "A", true, true, "A", "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A");
                        BOServerTask response = mapper.MapModelToBO("A", model);

                        response.CompletedTime.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.ConcurrencyTag.Should().Be("A");
                        response.Description.Should().Be("A");
                        response.DurationSeconds.Should().Be(1);
                        response.EnvironmentId.Should().Be("A");
                        response.ErrorMessage.Should().Be("A");
                        response.HasPendingInterruptions.Should().Be(true);
                        response.HasWarningsOrErrors.Should().Be(true);
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
                public void MapBOToModel()
                {
                        var mapper = new BOLServerTaskMapper();
                        BOServerTask bo = new BOServerTask();
                        bo.SetProperties("A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1, "A", "A", true, true, "A", "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A");
                        ApiServerTaskResponseModel response = mapper.MapBOToModel(bo);

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
                public void MapBOToModelList()
                {
                        var mapper = new BOLServerTaskMapper();
                        BOServerTask bo = new BOServerTask();
                        bo.SetProperties("A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1, "A", "A", true, true, "A", "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A");
                        List<ApiServerTaskResponseModel> response = mapper.MapBOToModel(new List<BOServerTask>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>301a079804ce03a851329a7274b4a899</Hash>
</Codenesium>*/