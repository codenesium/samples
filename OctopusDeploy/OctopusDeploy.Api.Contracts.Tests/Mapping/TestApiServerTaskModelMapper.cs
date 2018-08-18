using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ServerTask")]
	[Trait("Area", "ApiModel")]
	public class TestApiServerTaskModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiServerTaskModelMapper();
			var model = new ApiServerTaskRequestModel();
			model.SetProperties(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1, "A", "A", true, true, "A", "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A");
			ApiServerTaskResponseModel response = mapper.MapRequestToResponse("A", model);

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
		public void MapResponseToRequest()
		{
			var mapper = new ApiServerTaskModelMapper();
			var model = new ApiServerTaskResponseModel();
			model.SetProperties("A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1, "A", "A", true, true, "A", "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A");
			ApiServerTaskRequestModel response = mapper.MapResponseToRequest(model);

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
		public void CreatePatch()
		{
			var mapper = new ApiServerTaskModelMapper();
			var model = new ApiServerTaskRequestModel();
			model.SetProperties(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1, "A", "A", true, true, "A", "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A");

			JsonPatchDocument<ApiServerTaskRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiServerTaskRequestModel();
			patch.ApplyTo(response);
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
	}
}

/*<Codenesium>
    <Hash>8127971317292e5b8b100b57659eaa72</Hash>
</Codenesium>*/