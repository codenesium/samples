using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractDALPostTypesMapper
	{
		public virtual PostTypes MapModelToEntity(
			int id,
			ApiPostTypesServerRequestModel model
			)
		{
			PostTypes item = new PostTypes();
			item.SetProperties(
				id,
				model.RwType);
			return item;
		}

		public virtual ApiPostTypesServerResponseModel MapEntityToModel(
			PostTypes item)
		{
			var model = new ApiPostTypesServerResponseModel();

			model.SetProperties(item.Id,
			                    item.RwType);

			return model;
		}

		public virtual List<ApiPostTypesServerResponseModel> MapEntityToModel(
			List<PostTypes> items)
		{
			List<ApiPostTypesServerResponseModel> response = new List<ApiPostTypesServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b52ab87eaced4fc5168361941992b30f</Hash>
</Codenesium>*/