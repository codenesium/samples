using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "OctopusServerNode")]
	[Trait("Area", "ApiModel")]
	public class TestApiOctopusServerNodeModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiOctopusServerNodeModelMapper();
			var model = new ApiOctopusServerNodeRequestModel();
			model.SetProperties(true, "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), 1, "A", "A");
			ApiOctopusServerNodeResponseModel response = mapper.MapRequestToResponse("A", model);

			response.Id.Should().Be("A");
			response.IsInMaintenanceMode.Should().Be(true);
			response.JSON.Should().Be("A");
			response.LastSeen.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
			response.MaxConcurrentTasks.Should().Be(1);
			response.Name.Should().Be("A");
			response.Rank.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiOctopusServerNodeModelMapper();
			var model = new ApiOctopusServerNodeResponseModel();
			model.SetProperties("A", true, "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), 1, "A", "A");
			ApiOctopusServerNodeRequestModel response = mapper.MapResponseToRequest(model);

			response.IsInMaintenanceMode.Should().Be(true);
			response.JSON.Should().Be("A");
			response.LastSeen.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
			response.MaxConcurrentTasks.Should().Be(1);
			response.Name.Should().Be("A");
			response.Rank.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiOctopusServerNodeModelMapper();
			var model = new ApiOctopusServerNodeRequestModel();
			model.SetProperties(true, "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), 1, "A", "A");

			JsonPatchDocument<ApiOctopusServerNodeRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiOctopusServerNodeRequestModel();
			patch.ApplyTo(response);
			response.IsInMaintenanceMode.Should().Be(true);
			response.JSON.Should().Be("A");
			response.LastSeen.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
			response.MaxConcurrentTasks.Should().Be(1);
			response.Name.Should().Be("A");
			response.Rank.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>cb88b59dcba9f61d59129702240c8604</Hash>
</Codenesium>*/