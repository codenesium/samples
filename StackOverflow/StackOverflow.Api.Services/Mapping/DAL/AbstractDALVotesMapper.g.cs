using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractDALVotesMapper
	{
		public virtual Votes MapModelToEntity(
			int id,
			ApiVotesServerRequestModel model
			)
		{
			Votes item = new Votes();
			item.SetProperties(
				id,
				model.BountyAmount,
				model.CreationDate,
				model.PostId,
				model.UserId,
				model.VoteTypeId);
			return item;
		}

		public virtual ApiVotesServerResponseModel MapEntityToModel(
			Votes item)
		{
			var model = new ApiVotesServerResponseModel();

			model.SetProperties(item.Id,
			                    item.BountyAmount,
			                    item.CreationDate,
			                    item.PostId,
			                    item.UserId,
			                    item.VoteTypeId);
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

			if (item.VoteTypeIdNavigation != null)
			{
				var voteTypeIdModel = new ApiVoteTypesServerResponseModel();
				voteTypeIdModel.SetProperties(
					item.VoteTypeIdNavigation.Id,
					item.VoteTypeIdNavigation.Name);

				model.SetVoteTypeIdNavigation(voteTypeIdModel);
			}

			return model;
		}

		public virtual List<ApiVotesServerResponseModel> MapEntityToModel(
			List<Votes> items)
		{
			List<ApiVotesServerResponseModel> response = new List<ApiVotesServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>aef7bb731c8d4fdec29cf2e7884eb6d0</Hash>
</Codenesium>*/