using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractDALPostTypeMapper
	{
		public virtual PostType MapModelToEntity(
			int id,
			ApiPostTypeServerRequestModel model
			)
		{
			PostType item = new PostType();
			item.SetProperties(
				id,
				model.Type);
			return item;
		}

		public virtual ApiPostTypeServerResponseModel MapEntityToModel(
			PostType item)
		{
			var model = new ApiPostTypeServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Type);

			return model;
		}

		public virtual List<ApiPostTypeServerResponseModel> MapEntityToModel(
			List<PostType> items)
		{
			List<ApiPostTypeServerResponseModel> response = new List<ApiPostTypeServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>f26e1a59f6ec6d90677ea8939413707b</Hash>
</Codenesium>*/