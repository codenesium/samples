using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "MachinePolicy")]
	[Trait("Area", "ApiModel")]
	public class TestApiMachinePolicyModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiMachinePolicyModelMapper();
			var model = new ApiMachinePolicyRequestModel();
			model.SetProperties(true, "A", "A");
			ApiMachinePolicyResponseModel response = mapper.MapRequestToResponse("A", model);

			response.Id.Should().Be("A");
			response.IsDefault.Should().Be(true);
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiMachinePolicyModelMapper();
			var model = new ApiMachinePolicyResponseModel();
			model.SetProperties("A", true, "A", "A");
			ApiMachinePolicyRequestModel response = mapper.MapResponseToRequest(model);

			response.IsDefault.Should().Be(true);
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiMachinePolicyModelMapper();
			var model = new ApiMachinePolicyRequestModel();
			model.SetProperties(true, "A", "A");

			JsonPatchDocument<ApiMachinePolicyRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiMachinePolicyRequestModel();
			patch.ApplyTo(response);
			response.IsDefault.Should().Be(true);
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>747b5c879ea15804e15886afab2ea081</Hash>
</Codenesium>*/