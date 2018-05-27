using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.BusinessObjects
{
	public abstract class AbstractBOLMachineRefTeamMapper
	{
		public virtual DTOMachineRefTeam MapModelToDTO(
			int id,
			ApiMachineRefTeamRequestModel model
			)
		{
			DTOMachineRefTeam dtoMachineRefTeam = new DTOMachineRefTeam();

			dtoMachineRefTeam.SetProperties(
				id,
				model.MachineId,
				model.TeamId);
			return dtoMachineRefTeam;
		}

		public virtual ApiMachineRefTeamResponseModel MapDTOToModel(
			DTOMachineRefTeam dtoMachineRefTeam)
		{
			if (dtoMachineRefTeam == null)
			{
				return null;
			}

			var model = new ApiMachineRefTeamResponseModel();

			model.SetProperties(dtoMachineRefTeam.Id, dtoMachineRefTeam.MachineId, dtoMachineRefTeam.TeamId);

			return model;
		}

		public virtual List<ApiMachineRefTeamResponseModel> MapDTOToModel(
			List<DTOMachineRefTeam> dtos)
		{
			List<ApiMachineRefTeamResponseModel> response = new List<ApiMachineRefTeamResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b2b61186dcaacb26c08e7ec986adc107</Hash>
</Codenesium>*/