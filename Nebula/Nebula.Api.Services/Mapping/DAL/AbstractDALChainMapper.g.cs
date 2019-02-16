using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractDALChainMapper
	{
		public virtual Chain MapModelToEntity(
			int id,
			ApiChainServerRequestModel model
			)
		{
			Chain item = new Chain();
			item.SetProperties(
				id,
				model.ChainStatusId,
				model.ExternalId,
				model.Name,
				model.TeamId);
			return item;
		}

		public virtual ApiChainServerResponseModel MapEntityToModel(
			Chain item)
		{
			var model = new ApiChainServerResponseModel();

			model.SetProperties(item.Id,
			                    item.ChainStatusId,
			                    item.ExternalId,
			                    item.Name,
			                    item.TeamId);
			if (item.ChainStatusIdNavigation != null)
			{
				var chainStatusIdModel = new ApiChainStatusServerResponseModel();
				chainStatusIdModel.SetProperties(
					item.Id,
					item.ChainStatusIdNavigation.Name);

				model.SetChainStatusIdNavigation(chainStatusIdModel);
			}

			if (item.TeamIdNavigation != null)
			{
				var teamIdModel = new ApiTeamServerResponseModel();
				teamIdModel.SetProperties(
					item.Id,
					item.TeamIdNavigation.Name,
					item.TeamIdNavigation.OrganizationId);

				model.SetTeamIdNavigation(teamIdModel);
			}

			return model;
		}

		public virtual List<ApiChainServerResponseModel> MapEntityToModel(
			List<Chain> items)
		{
			List<ApiChainServerResponseModel> response = new List<ApiChainServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>506ff5a42dc0f286485ebe29f917d31d</Hash>
</Codenesium>*/