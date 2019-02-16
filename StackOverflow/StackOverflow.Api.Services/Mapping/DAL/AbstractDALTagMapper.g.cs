using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractDALTagMapper
	{
		public virtual Tag MapModelToEntity(
			int id,
			ApiTagServerRequestModel model
			)
		{
			Tag item = new Tag();
			item.SetProperties(
				id,
				model.Count,
				model.ExcerptPostId,
				model.TagName,
				model.WikiPostId);
			return item;
		}

		public virtual ApiTagServerResponseModel MapEntityToModel(
			Tag item)
		{
			var model = new ApiTagServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Count,
			                    item.ExcerptPostId,
			                    item.TagName,
			                    item.WikiPostId);

			return model;
		}

		public virtual List<ApiTagServerResponseModel> MapEntityToModel(
			List<Tag> items)
		{
			List<ApiTagServerResponseModel> response = new List<ApiTagServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b0bad6bdb7c86366cdedb286ddc7e364</Hash>
</Codenesium>*/