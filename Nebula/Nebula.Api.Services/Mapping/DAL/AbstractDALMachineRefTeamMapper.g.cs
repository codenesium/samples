using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractDALMachineRefTeamMapper
	{
		public virtual MachineRefTeam MapModelToEntity(
			int id,
			ApiMachineRefTeamServerRequestModel model
			)
		{
			MachineRefTeam item = new MachineRefTeam();
			item.SetProperties(
				id,
				model.MachineId,
				model.TeamId);
			return item;
		}

		public virtual ApiMachineRefTeamServerResponseModel MapEntityToModel(
			MachineRefTeam item)
		{
			var model = new ApiMachineRefTeamServerResponseModel();

			model.SetProperties(item.Id,
			                    item.MachineId,
			                    item.TeamId);
			if (item.MachineIdNavigation != null)
			{
				var machineIdModel = new ApiMachineServerResponseModel();
				machineIdModel.SetProperties(
					item.MachineIdNavigation.Id,
					item.MachineIdNavigation.Description,
					item.MachineIdNavigation.JwtKey,
					item.MachineIdNavigation.LastIpAddress,
					item.MachineIdNavigation.MachineGuid,
					item.MachineIdNavigation.Name);

				model.SetMachineIdNavigation(machineIdModel);
			}

			if (item.TeamIdNavigation != null)
			{
				var teamIdModel = new ApiTeamServerResponseModel();
				teamIdModel.SetProperties(
					item.TeamIdNavigation.Id,
					item.TeamIdNavigation.Name,
					item.TeamIdNavigation.OrganizationId);

				model.SetTeamIdNavigation(teamIdModel);
			}

			return model;
		}

		public virtual List<ApiMachineRefTeamServerResponseModel> MapEntityToModel(
			List<MachineRefTeam> items)
		{
			List<ApiMachineRefTeamServerResponseModel> response = new List<ApiMachineRefTeamServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>6a1c9ec2bf48ae84be8c93c56538f318</Hash>
</Codenesium>*/