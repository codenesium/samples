using FluentAssertions;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "MachineRefTeam")]
	[Trait("Area", "DALMapper")]
	public class TestDALMachineRefTeamMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALMachineRefTeamMapper();
			ApiMachineRefTeamServerRequestModel model = new ApiMachineRefTeamServerRequestModel();
			model.SetProperties(1, 1);
			MachineRefTeam response = mapper.MapModelToEntity(1, model);

			response.MachineId.Should().Be(1);
			response.TeamId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALMachineRefTeamMapper();
			MachineRefTeam item = new MachineRefTeam();
			item.SetProperties(1, 1, 1);
			ApiMachineRefTeamServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.MachineId.Should().Be(1);
			response.TeamId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALMachineRefTeamMapper();
			MachineRefTeam item = new MachineRefTeam();
			item.SetProperties(1, 1, 1);
			List<ApiMachineRefTeamServerResponseModel> response = mapper.MapEntityToModel(new List<MachineRefTeam>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>7361e7773b3cbfc13cfa63ac1d359ed4</Hash>
</Codenesium>*/