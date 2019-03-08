using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StackOverflowNS.Api.Client
{
	public partial class ApiResponse
	{
		public ApiResponse()
		{
		}

		public void Merge(ApiResponse from)
		{
			from.Badges.ForEach(x => this.AddBadges(x));
			from.Comments.ForEach(x => this.AddComments(x));
			from.LinkTypes.ForEach(x => this.AddLinkTypes(x));
			from.PostHistory.ForEach(x => this.AddPostHistory(x));
			from.PostHistoryTypes.ForEach(x => this.AddPostHistoryTypes(x));
			from.PostLinks.ForEach(x => this.AddPostLinks(x));
			from.Posts.ForEach(x => this.AddPosts(x));
			from.PostTypes.ForEach(x => this.AddPostTypes(x));
			from.Tags.ForEach(x => this.AddTags(x));
			from.Users.ForEach(x => this.AddUsers(x));
			from.Votes.ForEach(x => this.AddVotes(x));
			from.VoteTypes.ForEach(x => this.AddVoteTypes(x));
		}

		public List<ApiBadgesClientResponseModel> Badges { get; private set; } = new List<ApiBadgesClientResponseModel>();

		public List<ApiCommentsClientResponseModel> Comments { get; private set; } = new List<ApiCommentsClientResponseModel>();

		public List<ApiLinkTypesClientResponseModel> LinkTypes { get; private set; } = new List<ApiLinkTypesClientResponseModel>();

		public List<ApiPostHistoryClientResponseModel> PostHistory { get; private set; } = new List<ApiPostHistoryClientResponseModel>();

		public List<ApiPostHistoryTypesClientResponseModel> PostHistoryTypes { get; private set; } = new List<ApiPostHistoryTypesClientResponseModel>();

		public List<ApiPostLinksClientResponseModel> PostLinks { get; private set; } = new List<ApiPostLinksClientResponseModel>();

		public List<ApiPostsClientResponseModel> Posts { get; private set; } = new List<ApiPostsClientResponseModel>();

		public List<ApiPostTypesClientResponseModel> PostTypes { get; private set; } = new List<ApiPostTypesClientResponseModel>();

		public List<ApiTagsClientResponseModel> Tags { get; private set; } = new List<ApiTagsClientResponseModel>();

		public List<ApiUsersClientResponseModel> Users { get; private set; } = new List<ApiUsersClientResponseModel>();

		public List<ApiVotesClientResponseModel> Votes { get; private set; } = new List<ApiVotesClientResponseModel>();

		public List<ApiVoteTypesClientResponseModel> VoteTypes { get; private set; } = new List<ApiVoteTypesClientResponseModel>();

		public void AddBadges(ApiBadgesClientResponseModel item)
		{
			if (!this.Badges.Any(x => x.Id == item.Id))
			{
				this.Badges.Add(item);
			}
		}

		public void AddComments(ApiCommentsClientResponseModel item)
		{
			if (!this.Comments.Any(x => x.Id == item.Id))
			{
				this.Comments.Add(item);
			}
		}

		public void AddLinkTypes(ApiLinkTypesClientResponseModel item)
		{
			if (!this.LinkTypes.Any(x => x.Id == item.Id))
			{
				this.LinkTypes.Add(item);
			}
		}

		public void AddPostHistory(ApiPostHistoryClientResponseModel item)
		{
			if (!this.PostHistory.Any(x => x.Id == item.Id))
			{
				this.PostHistory.Add(item);
			}
		}

		public void AddPostHistoryTypes(ApiPostHistoryTypesClientResponseModel item)
		{
			if (!this.PostHistoryTypes.Any(x => x.Id == item.Id))
			{
				this.PostHistoryTypes.Add(item);
			}
		}

		public void AddPostLinks(ApiPostLinksClientResponseModel item)
		{
			if (!this.PostLinks.Any(x => x.Id == item.Id))
			{
				this.PostLinks.Add(item);
			}
		}

		public void AddPosts(ApiPostsClientResponseModel item)
		{
			if (!this.Posts.Any(x => x.Id == item.Id))
			{
				this.Posts.Add(item);
			}
		}

		public void AddPostTypes(ApiPostTypesClientResponseModel item)
		{
			if (!this.PostTypes.Any(x => x.Id == item.Id))
			{
				this.PostTypes.Add(item);
			}
		}

		public void AddTags(ApiTagsClientResponseModel item)
		{
			if (!this.Tags.Any(x => x.Id == item.Id))
			{
				this.Tags.Add(item);
			}
		}

		public void AddUsers(ApiUsersClientResponseModel item)
		{
			if (!this.Users.Any(x => x.Id == item.Id))
			{
				this.Users.Add(item);
			}
		}

		public void AddVotes(ApiVotesClientResponseModel item)
		{
			if (!this.Votes.Any(x => x.Id == item.Id))
			{
				this.Votes.Add(item);
			}
		}

		public void AddVoteTypes(ApiVoteTypesClientResponseModel item)
		{
			if (!this.VoteTypes.Any(x => x.Id == item.Id))
			{
				this.VoteTypes.Add(item);
			}
		}
	}
}

/*<Codenesium>
    <Hash>d9c486356d32dc94058d7e46c3cdf35e</Hash>
</Codenesium>*/