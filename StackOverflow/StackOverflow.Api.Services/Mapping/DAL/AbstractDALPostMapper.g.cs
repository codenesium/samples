using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractDALPostMapper
	{
		public virtual Post MapModelToEntity(
			int id,
			ApiPostServerRequestModel model
			)
		{
			Post item = new Post();
			item.SetProperties(
				id,
				model.AcceptedAnswerId,
				model.AnswerCount,
				model.Body,
				model.ClosedDate,
				model.CommentCount,
				model.CommunityOwnedDate,
				model.CreationDate,
				model.FavoriteCount,
				model.LastActivityDate,
				model.LastEditDate,
				model.LastEditorDisplayName,
				model.LastEditorUserId,
				model.OwnerUserId,
				model.ParentId,
				model.PostTypeId,
				model.Score,
				model.Tag,
				model.Title,
				model.ViewCount);
			return item;
		}

		public virtual ApiPostServerResponseModel MapEntityToModel(
			Post item)
		{
			var model = new ApiPostServerResponseModel();

			model.SetProperties(item.Id,
			                    item.AcceptedAnswerId,
			                    item.AnswerCount,
			                    item.Body,
			                    item.ClosedDate,
			                    item.CommentCount,
			                    item.CommunityOwnedDate,
			                    item.CreationDate,
			                    item.FavoriteCount,
			                    item.LastActivityDate,
			                    item.LastEditDate,
			                    item.LastEditorDisplayName,
			                    item.LastEditorUserId,
			                    item.OwnerUserId,
			                    item.ParentId,
			                    item.PostTypeId,
			                    item.Score,
			                    item.Tag,
			                    item.Title,
			                    item.ViewCount);

			return model;
		}

		public virtual List<ApiPostServerResponseModel> MapEntityToModel(
			List<Post> items)
		{
			List<ApiPostServerResponseModel> response = new List<ApiPostServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>eb33e2b7e86f259304227e3f2833050f</Hash>
</Codenesium>*/