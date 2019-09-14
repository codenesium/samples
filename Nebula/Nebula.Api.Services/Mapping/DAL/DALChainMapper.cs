using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public class DALChainMapper : IDALChainMapper
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
					item.ChainStatusIdNavigation.Id,
					item.ChainStatusIdNavigation.Name);

				model.SetChainStatusIdNavigation(chainStatusIdModel);
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
    <Hash>1a0430ce931c260930d58547a22212bf</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/