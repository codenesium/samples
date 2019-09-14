using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public class DALLinkStatusMapper : IDALLinkStatusMapper
	{
		public virtual LinkStatus MapModelToEntity(
			int id,
			ApiLinkStatusServerRequestModel model
			)
		{
			LinkStatus item = new LinkStatus();
			item.SetProperties(
				id,
				model.Name);
			return item;
		}

		public virtual ApiLinkStatusServerResponseModel MapEntityToModel(
			LinkStatus item)
		{
			var model = new ApiLinkStatusServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name);

			return model;
		}

		public virtual List<ApiLinkStatusServerResponseModel> MapEntityToModel(
			List<LinkStatus> items)
		{
			List<ApiLinkStatusServerResponseModel> response = new List<ApiLinkStatusServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>20f3cb8ed527543cc854c9c52ace5ca9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/