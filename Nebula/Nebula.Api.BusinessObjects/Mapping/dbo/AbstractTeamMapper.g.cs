using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.BusinessObjects
{
	public abstract class AbstractBOLTeamMapper
	{
		public virtual DTOTeam MapModelToDTO(
			int id,
			ApiTeamRequestModel model
			)
		{
			DTOTeam dtoTeam = new DTOTeam();

			dtoTeam.SetProperties(
				id,
				model.Name,
				model.OrganizationId);
			return dtoTeam;
		}

		public virtual ApiTeamResponseModel MapDTOToModel(
			DTOTeam dtoTeam)
		{
			if (dtoTeam == null)
			{
				return null;
			}

			var model = new ApiTeamResponseModel();

			model.SetProperties(dtoTeam.Id, dtoTeam.Name, dtoTeam.OrganizationId);

			return model;
		}

		public virtual List<ApiTeamResponseModel> MapDTOToModel(
			List<DTOTeam> dtos)
		{
			List<ApiTeamResponseModel> response = new List<ApiTeamResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>13cf391d17f29e738a29dea9107eaafc</Hash>
</Codenesium>*/