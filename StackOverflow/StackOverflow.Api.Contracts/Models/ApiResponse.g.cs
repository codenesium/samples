using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StackOverflowNS.Api.Contracts
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

		public List<ApiBadgeResponseModel> Badges { get; private set; } = new List<ApiBadgeResponseModel>();

		public List<ApiCommentResponseModel> Comments { get; private set; } = new List<ApiCommentResponseModel>();

		public List<ApiLinkTypeResponseModel> LinkTypes { get; private set; } = new List<ApiLinkTypeResponseModel>();

		public List<ApiPostHistoryResponseModel> PostHistories { get; private set; } = new List<ApiPostHistoryResponseModel>();

		public List<ApiPostHistoryTypeResponseModel> PostHistoryTypes { get; private set; } = new List<ApiPostHistoryTypeResponseModel>();

		public List<ApiPostLinkResponseModel> PostLinks { get; private set; } = new List<ApiPostLinkResponseModel>();

		public List<ApiPostResponseModel> Posts { get; private set; } = new List<ApiPostResponseModel>();

		public List<ApiPostTypeResponseModel> PostTypes { get; private set; } = new List<ApiPostTypeResponseModel>();

		public List<ApiTagResponseModel> Tags { get; private set; } = new List<ApiTagResponseModel>();

		public List<ApiUserResponseModel> Users { get; private set; } = new List<ApiUserResponseModel>();

		public List<ApiVoteResponseModel> Votes { get; private set; } = new List<ApiVoteResponseModel>();

		public List<ApiVoteTypeResponseModel> VoteTypes { get; private set; } = new List<ApiVoteTypeResponseModel>();

		[JsonIgnore]
		public bool ShouldSerializeBadgesValue { get; private set; } = true;

		public bool ShouldSerializeBadges()
		{
			return this.ShouldSerializeBadgesValue;
		}

		public void AddBadge(ApiBadgeResponseModel item)
		{
			if (!this.Badges.Any(x => x.Id == item.Id))
			{
				this.Badges.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeCommentsValue { get; private set; } = true;

		public bool ShouldSerializeComments()
		{
			return this.ShouldSerializeCommentsValue;
		}

		public void AddComment(ApiCommentResponseModel item)
		{
			if (!this.Comments.Any(x => x.Id == item.Id))
			{
				this.Comments.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeLinkTypesValue { get; private set; } = true;

		public bool ShouldSerializeLinkTypes()
		{
			return this.ShouldSerializeLinkTypesValue;
		}

		public void AddLinkType(ApiLinkTypeResponseModel item)
		{
			if (!this.LinkTypes.Any(x => x.Id == item.Id))
			{
				this.LinkTypes.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializePostHistoriesValue { get; private set; } = true;

		public bool ShouldSerializePostHistories()
		{
			return this.ShouldSerializePostHistoriesValue;
		}

		public void AddPostHistory(ApiPostHistoryResponseModel item)
		{
			if (!this.PostHistories.Any(x => x.Id == item.Id))
			{
				this.PostHistories.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializePostHistoryTypesValue { get; private set; } = true;

		public bool ShouldSerializePostHistoryTypes()
		{
			return this.ShouldSerializePostHistoryTypesValue;
		}

		public void AddPostHistoryType(ApiPostHistoryTypeResponseModel item)
		{
			if (!this.PostHistoryTypes.Any(x => x.Id == item.Id))
			{
				this.PostHistoryTypes.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializePostLinksValue { get; private set; } = true;

		public bool ShouldSerializePostLinks()
		{
			return this.ShouldSerializePostLinksValue;
		}

		public void AddPostLink(ApiPostLinkResponseModel item)
		{
			if (!this.PostLinks.Any(x => x.Id == item.Id))
			{
				this.PostLinks.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializePostsValue { get; private set; } = true;

		public bool ShouldSerializePosts()
		{
			return this.ShouldSerializePostsValue;
		}

		public void AddPost(ApiPostResponseModel item)
		{
			if (!this.Posts.Any(x => x.Id == item.Id))
			{
				this.Posts.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializePostTypesValue { get; private set; } = true;

		public bool ShouldSerializePostTypes()
		{
			return this.ShouldSerializePostTypesValue;
		}

		public void AddPostType(ApiPostTypeResponseModel item)
		{
			if (!this.PostTypes.Any(x => x.Id == item.Id))
			{
				this.PostTypes.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeTagsValue { get; private set; } = true;

		public bool ShouldSerializeTags()
		{
			return this.ShouldSerializeTagsValue;
		}

		public void AddTag(ApiTagResponseModel item)
		{
			if (!this.Tags.Any(x => x.Id == item.Id))
			{
				this.Tags.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeUsersValue { get; private set; } = true;

		public bool ShouldSerializeUsers()
		{
			return this.ShouldSerializeUsersValue;
		}

		public void AddUser(ApiUserResponseModel item)
		{
			if (!this.Users.Any(x => x.Id == item.Id))
			{
				this.Users.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeVotesValue { get; private set; } = true;

		public bool ShouldSerializeVotes()
		{
			return this.ShouldSerializeVotesValue;
		}

		public void AddVote(ApiVoteResponseModel item)
		{
			if (!this.Votes.Any(x => x.Id == item.Id))
			{
				this.Votes.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeVoteTypesValue { get; private set; } = true;

		public bool ShouldSerializeVoteTypes()
		{
			return this.ShouldSerializeVoteTypesValue;
		}

		public void AddVoteType(ApiVoteTypeResponseModel item)
		{
			if (!this.VoteTypes.Any(x => x.Id == item.Id))
			{
				this.VoteTypes.Add(item);
			}
		}

		public void DisableSerializationOfEmptyFields()
		{
			if (this.Badges.Count == 0)
			{
				this.ShouldSerializeBadgesValue = false;
			}

			if (this.Comments.Count == 0)
			{
				this.ShouldSerializeCommentsValue = false;
			}

			if (this.LinkTypes.Count == 0)
			{
				this.ShouldSerializeLinkTypesValue = false;
			}

			if (this.PostHistories.Count == 0)
			{
				this.ShouldSerializePostHistoriesValue = false;
			}

			if (this.PostHistoryTypes.Count == 0)
			{
				this.ShouldSerializePostHistoryTypesValue = false;
			}

			if (this.PostLinks.Count == 0)
			{
				this.ShouldSerializePostLinksValue = false;
			}

			if (this.Posts.Count == 0)
			{
				this.ShouldSerializePostsValue = false;
			}

			if (this.PostTypes.Count == 0)
			{
				this.ShouldSerializePostTypesValue = false;
			}

			if (this.Tags.Count == 0)
			{
				this.ShouldSerializeTagsValue = false;
			}

			if (this.Users.Count == 0)
			{
				this.ShouldSerializeUsersValue = false;
			}

			if (this.Votes.Count == 0)
			{
				this.ShouldSerializeVotesValue = false;
			}

			if (this.VoteTypes.Count == 0)
			{
				this.ShouldSerializeVoteTypesValue = false;
			}
		}
	}
}

/*<Codenesium>
    <Hash>1e41e0796bfade6da325d5e5ab2d0dd3</Hash>
</Codenesium>*/