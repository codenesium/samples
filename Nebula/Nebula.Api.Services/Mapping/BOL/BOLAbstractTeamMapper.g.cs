using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public abstract class BOLAbstractTeamMapper
	{
		public virtual BOTeam MapModelToBO(
			int id,
			ApiTeamServerRequestModel model
			)
		{
			BOTeam boTeam = new BOTeam();
			boTeam.SetProperties(
				id,
				model.Name,
				model.OrganizationId);
			return boTeam;
		}

		public virtual ApiTeamServerResponseModel MapBOToModel(
			BOTeam boTeam)
		{
			var model = new ApiTeamServerResponseModel();

			model.SetProperties(boTeam.Id, boTeam.Name, boTeam.OrganizationId);

			return model;
		}

		public virtual List<ApiTeamServerResponseModel> MapBOToModel(
			List<BOTeam> items)
		{
			List<ApiTeamServerResponseModel> response = new List<ApiTeamServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>276c9130929ae2acd2328d3cc83e933d</Hash>
</Codenesium>*/