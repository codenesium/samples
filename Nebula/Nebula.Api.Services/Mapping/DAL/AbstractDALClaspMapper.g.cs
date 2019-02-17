using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractDALClaspMapper
	{
		public virtual Clasp MapModelToEntity(
			int id,
			ApiClaspServerRequestModel model
			)
		{
			Clasp item = new Clasp();
			item.SetProperties(
				id,
				model.NextChainId,
				model.PreviousChainId);
			return item;
		}

		public virtual ApiClaspServerResponseModel MapEntityToModel(
			Clasp item)
		{
			var model = new ApiClaspServerResponseModel();

			model.SetProperties(item.Id,
			                    item.NextChainId,
			                    item.PreviousChainId);
			if (item.NextChainIdNavigation != null)
			{
				var nextChainIdModel = new ApiChainServerResponseModel();
				nextChainIdModel.SetProperties(
					item.NextChainIdNavigation.Id,
					item.NextChainIdNavigation.ChainStatusId,
					item.NextChainIdNavigation.ExternalId,
					item.NextChainIdNavigation.Name,
					item.NextChainIdNavigation.TeamId);

				model.SetNextChainIdNavigation(nextChainIdModel);
			}

			if (item.PreviousChainIdNavigation != null)
			{
				var previousChainIdModel = new ApiChainServerResponseModel();
				previousChainIdModel.SetProperties(
					item.PreviousChainIdNavigation.Id,
					item.PreviousChainIdNavigation.ChainStatusId,
					item.PreviousChainIdNavigation.ExternalId,
					item.PreviousChainIdNavigation.Name,
					item.PreviousChainIdNavigation.TeamId);

				model.SetPreviousChainIdNavigation(previousChainIdModel);
			}

			return model;
		}

		public virtual List<ApiClaspServerResponseModel> MapEntityToModel(
			List<Clasp> items)
		{
			List<ApiClaspServerResponseModel> response = new List<ApiClaspServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>200583b156af56c9279c3eb161397cb4</Hash>
</Codenesium>*/