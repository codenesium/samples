using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractDALChainStatusMapper
	{
		public virtual ChainStatus MapModelToEntity(
			int id,
			ApiChainStatusServerRequestModel model
			)
		{
			ChainStatus item = new ChainStatus();
			item.SetProperties(
				id,
				model.Name);
			return item;
		}

		public virtual ApiChainStatusServerResponseModel MapEntityToModel(
			ChainStatus item)
		{
			var model = new ApiChainStatusServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name);

			return model;
		}

		public virtual List<ApiChainStatusServerResponseModel> MapEntityToModel(
			List<ChainStatus> items)
		{
			List<ApiChainStatusServerResponseModel> response = new List<ApiChainStatusServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d9c7dda80e2d93fdb2ea65b14c10816f</Hash>
</Codenesium>*/