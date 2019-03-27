using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "MachineRefTeam")]
	[Trait("Area", "ApiModel")]
	public class TestApiMachineRefTeamModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiMachineRefTeamModelMapper();
			var model = new ApiMachineRefTeamClientRequestModel();
			model.SetProperties(1, 1);
			ApiMachineRefTeamClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.MachineId.Should().Be(1);
			response.TeamId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiMachineRefTeamModelMapper();
			var model = new ApiMachineRefTeamClientResponseModel();
			model.SetProperties(1, 1, 1);
			ApiMachineRefTeamClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.MachineId.Should().Be(1);
			response.TeamId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>623c060d22a11efa5921bc7a52f8d35c</Hash>
</Codenesium>*/