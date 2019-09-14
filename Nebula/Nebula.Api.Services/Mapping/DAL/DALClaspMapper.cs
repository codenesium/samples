using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public class DALClaspMapper : IDALClaspMapper
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
    <Hash>91904b3615f70298917881194c840bd4</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/