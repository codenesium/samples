using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "DeploymentRelatedMachine")]
	[Trait("Area", "ApiModel")]
	public class TestApiDeploymentRelatedMachineModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiDeploymentRelatedMachineModelMapper();
			var model = new ApiDeploymentRelatedMachineRequestModel();
			model.SetProperties("A", "A");
			ApiDeploymentRelatedMachineResponseModel response = mapper.MapRequestToResponse(1, model);

			response.DeploymentId.Should().Be("A");
			response.Id.Should().Be(1);
			response.MachineId.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiDeploymentRelatedMachineModelMapper();
			var model = new ApiDeploymentRelatedMachineResponseModel();
			model.SetProperties(1, "A", "A");
			ApiDeploymentRelatedMachineRequestModel response = mapper.MapResponseToRequest(model);

			response.DeploymentId.Should().Be("A");
			response.MachineId.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiDeploymentRelatedMachineModelMapper();
			var model = new ApiDeploymentRelatedMachineRequestModel();
			model.SetProperties("A", "A");

			JsonPatchDocument<ApiDeploymentRelatedMachineRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiDeploymentRelatedMachineRequestModel();
			patch.ApplyTo(response);
			response.DeploymentId.Should().Be("A");
			response.MachineId.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>5b33ae4d068eb254f41e80d1c475c819</Hash>
</Codenesium>*/