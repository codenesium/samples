using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class BOLAbstractPostMapper
	{
		public virtual BOPost MapModelToBO(
			int id,
			ApiPostRequestModel model
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

		public virtual ApiPostResponseModel MapBOToModel(
			BOPost boPost)
		{
			var model = new ApiPostResponseModel();

			model.SetProperties(boPost.Id, boPost.AcceptedAnswerId, boPost.AnswerCount, boPost.Body, boPost.ClosedDate, boPost.CommentCount, boPost.CommunityOwnedDate, boPost.CreationDate, boPost.FavoriteCount, boPost.LastActivityDate, boPost.LastEditDate, boPost.LastEditorDisplayName, boPost.LastEditorUserId, boPost.OwnerUserId, boPost.ParentId, boPost.PostTypeId, boPost.Score, boPost.Tag, boPost.Title, boPost.ViewCount);

			return model;
		}

		public virtual List<ApiPostResponseModel> MapBOToModel(
			List<BOPost> items)
		{
			List<ApiPostResponseModel> response = new List<ApiPostResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>f8b2be50001a7a6b08b94fa3ab65547b</Hash>
</Codenesium>*/