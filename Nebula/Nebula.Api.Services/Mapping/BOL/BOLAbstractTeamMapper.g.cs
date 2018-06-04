using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Services
{
	public abstract class BOLAbstractTeamMapper
	{
		public virtual BOTeam MapModelToBO(
			int id,
			ApiTeamRequestModel model
			)
		{
			BOTeam BOTeam = new BOTeam();

			BOTeam.SetProperties(
				id,
				model.Name,
				model.OrganizationId);
			return BOTeam;
		}

		public virtual ApiTeamResponseModel MapBOToModel(
			BOTeam BOTeam)
		{
			if (BOTeam == null)
			{
				return null;
			}

			var model = new ApiTeamResponseModel();

			model.SetProperties(BOTeam.Id, BOTeam.Name, BOTeam.OrganizationId);

			return model;
		}

		public virtual List<ApiTeamResponseModel> MapBOToModel(
			List<BOTeam> BOs)
		{
			List<ApiTeamResponseModel> response = new List<ApiTeamResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ae829e0f89e6dd19bdea195c72ce26f6</Hash>
</Codenesium>*/