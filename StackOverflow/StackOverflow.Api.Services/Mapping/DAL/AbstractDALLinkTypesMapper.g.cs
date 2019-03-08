using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractDALLinkTypesMapper
	{
		public virtual LinkTypes MapModelToEntity(
			int id,
			ApiLinkTypesServerRequestModel model
			)
		{
			LinkTypes item = new LinkTypes();
			item.SetProperties(
				id,
				model.RwType);
			return item;
		}

		public virtual ApiLinkTypesServerResponseModel MapEntityToModel(
			LinkTypes item)
		{
			var model = new ApiLinkTypesServerResponseModel();

			model.SetProperties(item.Id,
			                    item.RwType);

			return model;
		}

		public virtual List<ApiLinkTypesServerResponseModel> MapEntityToModel(
			List<LinkTypes> items)
		{
			List<ApiLinkTypesServerResponseModel> response = new List<ApiLinkTypesServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b8ca2bd033dbfb6fb083b923586dddd7</Hash>
</Codenesium>*/