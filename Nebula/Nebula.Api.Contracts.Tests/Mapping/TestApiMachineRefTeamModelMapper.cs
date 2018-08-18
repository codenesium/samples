using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using NebulaNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "MachineRefTeam")]
	[Trait("Area", "ApiModel")]
	public class TestApiMachineRefTeamModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiMachineRefTeamModelMapper();
			var model = new ApiMachineRefTeamRequestModel();
			model.SetProperties(1, 1);
			ApiMachineRefTeamResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.MachineId.Should().Be(1);
			response.TeamId.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiMachineRefTeamModelMapper();
			var model = new ApiMachineRefTeamResponseModel();
			model.SetProperties(1, 1, 1);
			ApiMachineRefTeamRequestModel response = mapper.MapResponseToRequest(model);

			response.MachineId.Should().Be(1);
			response.TeamId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiMachineRefTeamModelMapper();
			var model = new ApiMachineRefTeamRequestModel();
			model.SetProperties(1, 1);

			JsonPatchDocument<ApiMachineRefTeamRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiMachineRefTeamRequestModel();
			patch.ApplyTo(response);
			response.MachineId.Should().Be(1);
			response.TeamId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>e08704676042115d1b4a803288cd5027</Hash>
</Codenesium>*/