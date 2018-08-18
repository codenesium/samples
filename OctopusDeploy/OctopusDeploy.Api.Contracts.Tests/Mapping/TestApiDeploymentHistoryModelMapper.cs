using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "DeploymentHistory")]
	[Trait("Area", "ApiModel")]
	public class TestApiDeploymentHistoryModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiDeploymentHistoryModelMapper();
			var model = new ApiDeploymentHistoryRequestModel();
			model.SetProperties("A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1, "A", "A", "A", "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A");
			ApiDeploymentHistoryResponseModel response = mapper.MapRequestToResponse("A", model);

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
		public void MapResponseToRequest()
		{
			var mapper = new ApiDeploymentHistoryModelMapper();
			var model = new ApiDeploymentHistoryResponseModel();
			model.SetProperties("A", "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1, "A", "A", "A", "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A");
			ApiDeploymentHistoryRequestModel response = mapper.MapResponseToRequest(model);

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
		public void CreatePatch()
		{
			var mapper = new ApiDeploymentHistoryModelMapper();
			var model = new ApiDeploymentHistoryRequestModel();
			model.SetProperties("A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1, "A", "A", "A", "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A");

			JsonPatchDocument<ApiDeploymentHistoryRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiDeploymentHistoryRequestModel();
			patch.ApplyTo(response);
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
	}
}

/*<Codenesium>
    <Hash>3002fc3789d329a47c0deea28ae5d0b8</Hash>
</Codenesium>*/