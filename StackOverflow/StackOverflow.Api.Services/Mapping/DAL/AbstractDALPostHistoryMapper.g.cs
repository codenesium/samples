using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractDALPostHistoryMapper
	{
		public virtual PostHistory MapModelToEntity(
			int id,
			ApiPostHistoryServerRequestModel model
			)
		{
			PostHistory item = new PostHistory();
			item.SetProperties(
				id,
				model.Comment,
				model.CreationDate,
				model.PostHistoryTypeId,
				model.PostId,
				model.RevisionGUID,
				model.Text,
				model.UserDisplayName,
				model.UserId);
			return item;
		}

		public virtual ApiPostHistoryServerResponseModel MapEntityToModel(
			PostHistory item)
		{
			var model = new ApiPostHistoryServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Comment,
			                    item.CreationDate,
			                    item.PostHistoryTypeId,
			                    item.PostId,
			                    item.RevisionGUID,
			                    item.Text,
			                    item.UserDisplayName,
			                    item.UserId);

			return model;
		}

		public virtual List<ApiPostHistoryServerResponseModel> MapEntityToModel(
			List<PostHistory> items)
		{
			List<ApiPostHistoryServerResponseModel> response = new List<ApiPostHistoryServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b0c6483cfe9e35efeeb5d27db29d92db</Hash>
</Codenesium>*/