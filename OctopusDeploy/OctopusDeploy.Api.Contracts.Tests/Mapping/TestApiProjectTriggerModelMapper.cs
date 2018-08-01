using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ProjectTrigger")]
	[Trait("Area", "ApiModel")]
	public class TestApiProjectTriggerModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiProjectTriggerModelMapper();
			var model = new ApiProjectTriggerRequestModel();
			model.SetProperties(true, "A", "A", "A", "A");
			ApiProjectTriggerResponseModel response = mapper.MapRequestToResponse("A", model);

			response.Id.Should().Be("A");
			response.IsDisabled.Should().Be(true);
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
			response.ProjectId.Should().Be("A");
			response.TriggerType.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiProjectTriggerModelMapper();
			var model = new ApiProjectTriggerResponseModel();
			model.SetProperties("A", true, "A", "A", "A", "A");
			ApiProjectTriggerRequestModel response = mapper.MapResponseToRequest(model);

			response.IsDisabled.Should().Be(true);
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
			response.ProjectId.Should().Be("A");
			response.TriggerType.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiProjectTriggerModelMapper();
			var model = new ApiProjectTriggerRequestModel();
			model.SetProperties(true, "A", "A", "A", "A");

			JsonPatchDocument<ApiProjectTriggerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiProjectTriggerRequestModel();
			patch.ApplyTo(response);
			response.IsDisabled.Should().Be(true);
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
			response.ProjectId.Should().Be("A");
			response.TriggerType.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>790c3840b54465fbb9c09eb69d3c222d</Hash>
</Codenesium>*/