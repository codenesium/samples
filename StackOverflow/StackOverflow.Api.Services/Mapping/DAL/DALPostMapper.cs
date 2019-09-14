using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public class DALPostMapper : IDALPostMapper
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
			if (item.LastEditorUserIdNavigation != null)
			{
				var lastEditorUserIdModel = new ApiUserServerResponseModel();
				lastEditorUserIdModel.SetProperties(
					item.LastEditorUserIdNavigation.Id,
					item.LastEditorUserIdNavigation.AboutMe,
					item.LastEditorUserIdNavigation.AccountId,
					item.LastEditorUserIdNavigation.Age,
					item.LastEditorUserIdNavigation.CreationDate,
					item.LastEditorUserIdNavigation.DisplayName,
					item.LastEditorUserIdNavigation.DownVote,
					item.LastEditorUserIdNavigation.EmailHash,
					item.LastEditorUserIdNavigation.LastAccessDate,
					item.LastEditorUserIdNavigation.Location,
					item.LastEditorUserIdNavigation.Reputation,
					item.LastEditorUserIdNavigation.UpVote,
					item.LastEditorUserIdNavigation.View,
					item.LastEditorUserIdNavigation.WebsiteUrl);

				model.SetLastEditorUserIdNavigation(lastEditorUserIdModel);
			}

			if (item.OwnerUserIdNavigation != null)
			{
				var ownerUserIdModel = new ApiUserServerResponseModel();
				ownerUserIdModel.SetProperties(
					item.OwnerUserIdNavigation.Id,
					item.OwnerUserIdNavigation.AboutMe,
					item.OwnerUserIdNavigation.AccountId,
					item.OwnerUserIdNavigation.Age,
					item.OwnerUserIdNavigation.CreationDate,
					item.OwnerUserIdNavigation.DisplayName,
					item.OwnerUserIdNavigation.DownVote,
					item.OwnerUserIdNavigation.EmailHash,
					item.OwnerUserIdNavigation.LastAccessDate,
					item.OwnerUserIdNavigation.Location,
					item.OwnerUserIdNavigation.Reputation,
					item.OwnerUserIdNavigation.UpVote,
					item.OwnerUserIdNavigation.View,
					item.OwnerUserIdNavigation.WebsiteUrl);

				model.SetOwnerUserIdNavigation(ownerUserIdModel);
			}

			if (item.ParentIdNavigation != null)
			{
				var parentIdModel = new ApiPostServerResponseModel();
				parentIdModel.SetProperties(
					item.ParentIdNavigation.Id,
					item.ParentIdNavigation.AcceptedAnswerId,
					item.ParentIdNavigation.AnswerCount,
					item.ParentIdNavigation.Body,
					item.ParentIdNavigation.ClosedDate,
					item.ParentIdNavigation.CommentCount,
					item.ParentIdNavigation.CommunityOwnedDate,
					item.ParentIdNavigation.CreationDate,
					item.ParentIdNavigation.FavoriteCount,
					item.ParentIdNavigation.LastActivityDate,
					item.ParentIdNavigation.LastEditDate,
					item.ParentIdNavigation.LastEditorDisplayName,
					item.ParentIdNavigation.LastEditorUserId,
					item.ParentIdNavigation.OwnerUserId,
					item.ParentIdNavigation.ParentId,
					item.ParentIdNavigation.PostTypeId,
					item.ParentIdNavigation.Score,
					item.ParentIdNavigation.Tag,
					item.ParentIdNavigation.Title,
					item.ParentIdNavigation.ViewCount);

				model.SetParentIdNavigation(parentIdModel);
			}

			if (item.PostTypeIdNavigation != null)
			{
				var postTypeIdModel = new ApiPostTypeServerResponseModel();
				postTypeIdModel.SetProperties(
					item.PostTypeIdNavigation.Id,
					item.PostTypeIdNavigation.RwType);

				model.SetPostTypeIdNavigation(postTypeIdModel);
			}

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
    <Hash>83e2f3279682bb349dd6d98214bba47c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/