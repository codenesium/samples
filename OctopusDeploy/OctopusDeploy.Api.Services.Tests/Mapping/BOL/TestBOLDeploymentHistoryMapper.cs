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
	[Trait("Table", "DeploymentHistory")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLDeploymentHistoryMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLDeploymentHistoryMapper();
			ApiDeploymentHistoryRequestModel model = new ApiDeploymentHistoryRequestModel();
			model.SetProperties("A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1, "A", "A", "A", "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A");
			BODeploymentHistory response = mapper.MapModelToBO("A", model);

			response.ChannelId.Should().Be("A");
			response.ChannelName.Should().Be("A");
			response.CompletedTime.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
			response.Created.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
			response.DeployedBy.Should().Be("A");
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
		public void MapBOToModel()
		{
			var mapper = new BOLDeploymentHistoryMapper();
			BODeploymentHistory bo = new BODeploymentHistory();
			bo.SetProperties("A", "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1, "A", "A", "A", "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A");
			ApiDeploymentHistoryResponseModel response = mapper.MapBOToModel(bo);

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
		public void MapBOToModelList()
		{
			var mapper = new BOLDeploymentHistoryMapper();
			BODeploymentHistory bo = new BODeploymentHistory();
			bo.SetProperties("A", "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1, "A", "A", "A", "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A");
			List<ApiDeploymentHistoryResponseModel> response = mapper.MapBOToModel(new List<BODeploymentHistory>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>646b29ee8b103bd6c88b967229711124</Hash>
</Codenesium>*/