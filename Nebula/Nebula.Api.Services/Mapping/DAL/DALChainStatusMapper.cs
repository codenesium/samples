using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public class DALChainStatusMapper : IDALChainStatusMapper
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
    <Hash>8a8f96e643dbef379b55f78ce8eef9e0</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/