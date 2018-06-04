using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Services
{
	public abstract class BOLAbstractMachineRefTeamMapper
	{
		public virtual BOMachineRefTeam MapModelToBO(
			int id,
			ApiMachineRefTeamRequestModel model
			)
		{
			BOMachineRefTeam BOMachineRefTeam = new BOMachineRefTeam();

			BOMachineRefTeam.SetProperties(
				id,
				model.MachineId,
				model.TeamId);
			return BOMachineRefTeam;
		}

		public virtual ApiMachineRefTeamResponseModel MapBOToModel(
			BOMachineRefTeam BOMachineRefTeam)
		{
			if (BOMachineRefTeam == null)
			{
				return null;
			}

			var model = new ApiMachineRefTeamResponseModel();

			model.SetProperties(BOMachineRefTeam.Id, BOMachineRefTeam.MachineId, BOMachineRefTeam.TeamId);

			return model;
		}

		public virtual List<ApiMachineRefTeamResponseModel> MapBOToModel(
			List<BOMachineRefTeam> BOs)
		{
			List<ApiMachineRefTeamResponseModel> response = new List<ApiMachineRefTeamResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>af191152f4f519b9483fc9940e22382d</Hash>
</Codenesium>*/