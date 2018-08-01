using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public abstract class BOLAbstractMachineRefTeamMapper
	{
		public virtual BOMachineRefTeam MapModelToBO(
			int id,
			ApiMachineRefTeamRequestModel model
			)
		{
			BOMachineRefTeam boMachineRefTeam = new BOMachineRefTeam();
			boMachineRefTeam.SetProperties(
				id,
				model.MachineId,
				model.TeamId);
			return boMachineRefTeam;
		}

		public virtual ApiMachineRefTeamResponseModel MapBOToModel(
			BOMachineRefTeam boMachineRefTeam)
		{
			var model = new ApiMachineRefTeamResponseModel();

			model.SetProperties(boMachineRefTeam.Id, boMachineRefTeam.MachineId, boMachineRefTeam.TeamId);

			return model;
		}

		public virtual List<ApiMachineRefTeamResponseModel> MapBOToModel(
			List<BOMachineRefTeam> items)
		{
			List<ApiMachineRefTeamResponseModel> response = new List<ApiMachineRefTeamResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>5b96945c186555108050b08849d872a4</Hash>
</Codenesium>*/