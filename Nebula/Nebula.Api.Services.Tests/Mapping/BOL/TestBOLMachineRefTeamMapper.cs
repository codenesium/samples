using FluentAssertions;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "MachineRefTeam")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLMachineRefTeamMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLMachineRefTeamMapper();
			ApiMachineRefTeamRequestModel model = new ApiMachineRefTeamRequestModel();
			model.SetProperties(1, 1);
			BOMachineRefTeam response = mapper.MapModelToBO(1, model);

			response.MachineId.Should().Be(1);
			response.TeamId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLMachineRefTeamMapper();
			BOMachineRefTeam bo = new BOMachineRefTeam();
			bo.SetProperties(1, 1, 1);
			ApiMachineRefTeamResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.MachineId.Should().Be(1);
			response.TeamId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLMachineRefTeamMapper();
			BOMachineRefTeam bo = new BOMachineRefTeam();
			bo.SetProperties(1, 1, 1);
			List<ApiMachineRefTeamResponseModel> response = mapper.MapBOToModel(new List<BOMachineRefTeam>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>dba63e59caf335325d401073304fe64a</Hash>
</Codenesium>*/