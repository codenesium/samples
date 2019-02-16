using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractDALCommentMapper
	{
		public virtual Comment MapModelToEntity(
			int id,
			ApiCommentServerRequestModel model
			)
		{
			Comment item = new Comment();
			item.SetProperties(
				id,
				model.CreationDate,
				model.PostId,
				model.Score,
				model.Text,
				model.UserId);
			return item;
		}

		public virtual ApiCommentServerResponseModel MapEntityToModel(
			Comment item)
		{
			var model = new ApiCommentServerResponseModel();

			model.SetProperties(item.Id,
			                    item.CreationDate,
			                    item.PostId,
			                    item.Score,
			                    item.Text,
			                    item.UserId);

			return model;
		}

		public virtual List<ApiCommentServerResponseModel> MapEntityToModel(
			List<Comment> items)
		{
			List<ApiCommentServerResponseModel> response = new List<ApiCommentServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a76b53b60282cbef4e842b9d83f96f09</Hash>
</Codenesium>*/