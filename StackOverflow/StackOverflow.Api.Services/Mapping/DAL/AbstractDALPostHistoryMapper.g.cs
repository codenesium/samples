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
			if (item.PostHistoryTypeIdNavigation != null)
			{
				var postHistoryTypeIdModel = new ApiPostHistoryTypesServerResponseModel();
				postHistoryTypeIdModel.SetProperties(
					item.PostHistoryTypeIdNavigation.Id,
					item.PostHistoryTypeIdNavigation.RwType);

				model.SetPostHistoryTypeIdNavigation(postHistoryTypeIdModel);
			}

			if (item.PostIdNavigation != null)
			{
				var postIdModel = new ApiPostsServerResponseModel();
				postIdModel.SetProperties(
					item.PostIdNavigation.Id,
					item.PostIdNavigation.AcceptedAnswerId,
					item.PostIdNavigation.AnswerCount,
					item.PostIdNavigation.Body,
					item.PostIdNavigation.ClosedDate,
					item.PostIdNavigation.CommentCount,
					item.PostIdNavigation.CommunityOwnedDate,
					item.PostIdNavigation.CreationDate,
					item.PostIdNavigation.FavoriteCount,
					item.PostIdNavigation.LastActivityDate,
					item.PostIdNavigation.LastEditDate,
					item.PostIdNavigation.LastEditorDisplayName,
					item.PostIdNavigation.LastEditorUserId,
					item.PostIdNavigation.OwnerUserId,
					item.PostIdNavigation.ParentId,
					item.PostIdNavigation.PostTypeId,
					item.PostIdNavigation.Score,
					item.PostIdNavigation.Tag,
					item.PostIdNavigation.Title,
					item.PostIdNavigation.ViewCount);

				model.SetPostIdNavigation(postIdModel);
			}

			if (item.UserIdNavigation != null)
			{
				var userIdModel = new ApiUsersServerResponseModel();
				userIdModel.SetProperties(
					item.UserIdNavigation.Id,
					item.UserIdNavigation.AboutMe,
					item.UserIdNavigation.AccountId,
					item.UserIdNavigation.Age,
					item.UserIdNavigation.CreationDate,
					item.UserIdNavigation.DisplayName,
					item.UserIdNavigation.DownVote,
					item.UserIdNavigation.EmailHash,
					item.UserIdNavigation.LastAccessDate,
					item.UserIdNavigation.Location,
					item.UserIdNavigation.Reputation,
					item.UserIdNavigation.UpVote,
					item.UserIdNavigation.View,
					item.UserIdNavigation.WebsiteUrl);

				model.SetUserIdNavigation(userIdModel);
			}

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
    <Hash>af7d6c9a20d260db9f18600954506631</Hash>
</Codenesium>*/