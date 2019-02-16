using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractDALTeamMapper
	{
		public virtual Team MapModelToEntity(
			int id,
			ApiTeamServerRequestModel model
			)
		{
			Team item = new Team();
			item.SetProperties(
				id,
				model.Name,
				model.OrganizationId);
			return item;
		}

		public virtual ApiTeamServerResponseModel MapEntityToModel(
			Team item)
		{
			var model = new ApiTeamServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name,
			                    item.OrganizationId);
			if (item.OrganizationIdNavigation != null)
			{
				var organizationIdModel = new ApiOrganizationServerResponseModel();
				organizationIdModel.SetProperties(
					item.Id,
					item.OrganizationIdNavigation.Name);

				model.SetOrganizationIdNavigation(organizationIdModel);
			}

			return model;
		}

		public virtual List<ApiTeamServerResponseModel> MapEntityToModel(
			List<Team> items)
		{
			List<ApiTeamServerResponseModel> response = new List<ApiTeamServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>fdb14e82dc0625a35251d76a85f40007</Hash>
</Codenesium>*/