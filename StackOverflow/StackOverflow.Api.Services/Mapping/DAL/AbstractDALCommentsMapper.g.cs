using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractDALCommentsMapper
	{
		public virtual Comments MapModelToEntity(
			int id,
			ApiCommentsServerRequestModel model
			)
		{
			Comments item = new Comments();
			item.SetProperties(
				id,
				model.CreationDate,
				model.PostId,
				model.Score,
				model.Text,
				model.UserId);
			return item;
		}

		public virtual ApiCommentsServerResponseModel MapEntityToModel(
			Comments item)
		{
			var model = new ApiCommentsServerResponseModel();

			model.SetProperties(item.Id,
			                    item.CreationDate,
			                    item.PostId,
			                    item.Score,
			                    item.Text,
			                    item.UserId);
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

		public virtual List<ApiCommentsServerResponseModel> MapEntityToModel(
			List<Comments> items)
		{
			List<ApiCommentsServerResponseModel> response = new List<ApiCommentsServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>96ac3e510318a5804bb94ddef706832a</Hash>
</Codenesium>*/