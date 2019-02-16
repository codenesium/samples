using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractDALLinkStatusMapper
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
    <Hash>59e9efcf6529b6fd1d846e2161a75659</Hash>
</Codenesium>*/