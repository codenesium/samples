using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "MachineRefTeam")]
	[Trait("Area", "ApiModel")]
	public class TestApiMachineRefTeamServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiMachineRefTeamServerModelMapper();
			var model = new ApiMachineRefTeamServerRequestModel();
			model.SetProperties(1, 1);
			ApiMachineRefTeamServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.MachineId.Should().Be(1);
			response.TeamId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiMachineRefTeamServerModelMapper();
			var model = new ApiMachineRefTeamServerResponseModel();
			model.SetProperties(1, 1, 1);
			ApiMachineRefTeamServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.MachineId.Should().Be(1);
			response.TeamId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiMachineRefTeamServerModelMapper();
			var model = new ApiMachineRefTeamServerRequestModel();
			model.SetProperties(1, 1);

			JsonPatchDocument<ApiMachineRefTeamServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiMachineRefTeamServerRequestModel();
			patch.ApplyTo(response);
			response.MachineId.Should().Be(1);
			response.TeamId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>65306091f8e9a53c89ca508359b549fe</Hash>
</Codenesium>*/