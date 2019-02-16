using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractDALLinkTypeMapper
	{
		public virtual LinkType MapModelToEntity(
			int id,
			ApiLinkTypeServerRequestModel model
			)
		{
			LinkType item = new LinkType();
			item.SetProperties(
				id,
				model.Type);
			return item;
		}

		public virtual ApiLinkTypeServerResponseModel MapEntityToModel(
			LinkType item)
		{
			var model = new ApiLinkTypeServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Type);

			return model;
		}

		public virtual List<ApiLinkTypeServerResponseModel> MapEntityToModel(
			List<LinkType> items)
		{
			List<ApiLinkTypeServerResponseModel> response = new List<ApiLinkTypeServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>736d8e770c36cb823df472960af70beb</Hash>
</Codenesium>*/