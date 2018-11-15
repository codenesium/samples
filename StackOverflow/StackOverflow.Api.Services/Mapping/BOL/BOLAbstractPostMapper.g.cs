using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class BOLAbstractPostMapper
	{
		public virtual BOPost MapModelToBO(
			int id,
			ApiPostServerRequestModel model
			)
		{
			BOPost boPost = new BOPost();
			boPost.SetProperties(
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
			return boPost;
		}

		public virtual ApiPostServerResponseModel MapBOToModel(
			BOPost boPost)
		{
			var model = new ApiPostServerResponseModel();

			model.SetProperties(boPost.Id, boPost.AcceptedAnswerId, boPost.AnswerCount, boPost.Body, boPost.ClosedDate, boPost.CommentCount, boPost.CommunityOwnedDate, boPost.CreationDate, boPost.FavoriteCount, boPost.LastActivityDate, boPost.LastEditDate, boPost.LastEditorDisplayName, boPost.LastEditorUserId, boPost.OwnerUserId, boPost.ParentId, boPost.PostTypeId, boPost.Score, boPost.Tag, boPost.Title, boPost.ViewCount);

			return model;
		}

		public virtual List<ApiPostServerResponseModel> MapBOToModel(
			List<BOPost> items)
		{
			List<ApiPostServerResponseModel> response = new List<ApiPostServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>3eb7816b76f51a19159d60332043e5ed</Hash>
</Codenesium>*/