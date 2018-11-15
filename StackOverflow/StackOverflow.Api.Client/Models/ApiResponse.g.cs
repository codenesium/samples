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
			from.Badges.ForEach(x => this.AddBadge(x));
			from.Comments.ForEach(x => this.AddComment(x));
			from.LinkTypes.ForEach(x => this.AddLinkType(x));
			from.PostHistories.ForEach(x => this.AddPostHistory(x));
			from.PostHistoryTypes.ForEach(x => this.AddPostHistoryType(x));
			from.PostLinks.ForEach(x => this.AddPostLink(x));
			from.Posts.ForEach(x => this.AddPost(x));
			from.PostTypes.ForEach(x => this.AddPostType(x));
			from.Tags.ForEach(x => this.AddTag(x));
			from.Users.ForEach(x => this.AddUser(x));
			from.Votes.ForEach(x => this.AddVote(x));
			from.VoteTypes.ForEach(x => this.AddVoteType(x));
		}

		public List<ApiBadgeClientResponseModel> Badges { get; private set; } = new List<ApiBadgeClientResponseModel>();

		public List<ApiCommentClientResponseModel> Comments { get; private set; } = new List<ApiCommentClientResponseModel>();

		public List<ApiLinkTypeClientResponseModel> LinkTypes { get; private set; } = new List<ApiLinkTypeClientResponseModel>();

		public List<ApiPostHistoryClientResponseModel> PostHistories { get; private set; } = new List<ApiPostHistoryClientResponseModel>();

		public List<ApiPostHistoryTypeClientResponseModel> PostHistoryTypes { get; private set; } = new List<ApiPostHistoryTypeClientResponseModel>();

		public List<ApiPostLinkClientResponseModel> PostLinks { get; private set; } = new List<ApiPostLinkClientResponseModel>();

		public List<ApiPostClientResponseModel> Posts { get; private set; } = new List<ApiPostClientResponseModel>();

		public List<ApiPostTypeClientResponseModel> PostTypes { get; private set; } = new List<ApiPostTypeClientResponseModel>();

		public List<ApiTagClientResponseModel> Tags { get; private set; } = new List<ApiTagClientResponseModel>();

		public List<ApiUserClientResponseModel> Users { get; private set; } = new List<ApiUserClientResponseModel>();

		public List<ApiVoteClientResponseModel> Votes { get; private set; } = new List<ApiVoteClientResponseModel>();

		public List<ApiVoteTypeClientResponseModel> VoteTypes { get; private set; } = new List<ApiVoteTypeClientResponseModel>();

		public void AddBadge(ApiBadgeClientResponseModel item)
		{
			if (!this.Badges.Any(x => x.Id == item.Id))
			{
				this.Badges.Add(item);
			}
		}

		public void AddComment(ApiCommentClientResponseModel item)
		{
			if (!this.Comments.Any(x => x.Id == item.Id))
			{
				this.Comments.Add(item);
			}
		}

		public void AddLinkType(ApiLinkTypeClientResponseModel item)
		{
			if (!this.LinkTypes.Any(x => x.Id == item.Id))
			{
				this.LinkTypes.Add(item);
			}
		}

		public void AddPostHistory(ApiPostHistoryClientResponseModel item)
		{
			if (!this.PostHistories.Any(x => x.Id == item.Id))
			{
				this.PostHistories.Add(item);
			}
		}

		public void AddPostHistoryType(ApiPostHistoryTypeClientResponseModel item)
		{
			if (!this.PostHistoryTypes.Any(x => x.Id == item.Id))
			{
				this.PostHistoryTypes.Add(item);
			}
		}

		public void AddPostLink(ApiPostLinkClientResponseModel item)
		{
			if (!this.PostLinks.Any(x => x.Id == item.Id))
			{
				this.PostLinks.Add(item);
			}
		}

		public void AddPost(ApiPostClientResponseModel item)
		{
			if (!this.Posts.Any(x => x.Id == item.Id))
			{
				this.Posts.Add(item);
			}
		}

		public void AddPostType(ApiPostTypeClientResponseModel item)
		{
			if (!this.PostTypes.Any(x => x.Id == item.Id))
			{
				this.PostTypes.Add(item);
			}
		}

		public void AddTag(ApiTagClientResponseModel item)
		{
			if (!this.Tags.Any(x => x.Id == item.Id))
			{
				this.Tags.Add(item);
			}
		}

		public void AddUser(ApiUserClientResponseModel item)
		{
			if (!this.Users.Any(x => x.Id == item.Id))
			{
				this.Users.Add(item);
			}
		}

		public void AddVote(ApiVoteClientResponseModel item)
		{
			if (!this.Votes.Any(x => x.Id == item.Id))
			{
				this.Votes.Add(item);
			}
		}

		public void AddVoteType(ApiVoteTypeClientResponseModel item)
		{
			if (!this.VoteTypes.Any(x => x.Id == item.Id))
			{
				this.VoteTypes.Add(item);
			}
		}
	}
}

/*<Codenesium>
    <Hash>dafbbf1449f898903811c904a8182dad</Hash>
</Codenesium>*/