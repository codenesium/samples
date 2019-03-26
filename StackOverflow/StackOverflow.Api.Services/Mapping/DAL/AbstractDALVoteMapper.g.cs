using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractDALVoteMapper
	{
		public virtual Vote MapModelToEntity(
			int id,
			ApiVoteServerRequestModel model
			)
		{
			Vote item = new Vote();
			item.SetProperties(
				id,
				model.BountyAmount,
				model.CreationDate,
				model.PostId,
				model.UserId,
				model.VoteTypeId);
			return item;
		}

		public virtual ApiVoteServerResponseModel MapEntityToModel(
			Vote item)
		{
			var model = new ApiVoteServerResponseModel();

			model.SetProperties(item.Id,
			                    item.BountyAmount,
			                    item.CreationDate,
			                    item.PostId,
			                    item.UserId,
			                    item.VoteTypeId);
			if (item.PostIdNavigation != null)
			{
				var postIdModel = new ApiPostServerResponseModel();
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
				var userIdModel = new ApiUserServerResponseModel();
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

			if (item.VoteTypeIdNavigation != null)
			{
				var voteTypeIdModel = new ApiVoteTypeServerResponseModel();
				voteTypeIdModel.SetProperties(
					item.VoteTypeIdNavigation.Id,
					item.VoteTypeIdNavigation.Name);

				model.SetVoteTypeIdNavigation(voteTypeIdModel);
			}

			return model;
		}

		public virtual List<ApiVoteServerResponseModel> MapEntityToModel(
			List<Vote> items)
		{
			List<ApiVoteServerResponseModel> response = new List<ApiVoteServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>1e27aa43a4411a619ffab0388eae3ea5</Hash>
</Codenesium>*/